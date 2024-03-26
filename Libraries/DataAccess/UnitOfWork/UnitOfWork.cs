using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceContext Context;
        public UnitOfWork(ECommerceContext context)
        {
            Context = context;
        }
        public async Task<T> BeginTransaction<T>(Func<Task<T>> action)
        {
            var result = default(T);
            await Context.Database.CreateExecutionStrategy().ExecuteAsync(async () =>
            {
                await using var tx = Context.Database.BeginTransaction();
                try
                {
                    result = await action();
                    await Context.SaveChangesAsync();
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception("TransactionError", ex);
                }
            });
            return result;
        }
    }
}
