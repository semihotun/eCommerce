using eCommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace eCommerce.Core.DataAccess.EntitiyFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> 
        where TEntity : class,
        IEntity where TContext : DbContext  
    {
        protected readonly TContext Context;
        public EfEntityRepositoryBase(TContext context)
        {
            Context = context;
        }
        public TEntity GetById(int Id)
        {
            return Context.Set<TEntity>().Find(Id);
        }
        public TEntity Add(TEntity entity)
        {
            return Context.Add(entity).Entity;
        }
        public void AddRange(List<TEntity> entity)
        {
             Context.AddRange(entity);
        }
        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            return entity;
        }
        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
        }
        public void DeleteRange(List<TEntity> entity)
        {
            Context.RemoveRange(entity);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().FirstOrDefault(expression);
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? Context.Set<TEntity>().AsNoTracking() : Context.Set<TEntity>().Where(expression).AsNoTracking();
        }
        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? await Context.Set<TEntity>().ToListAsync() :
                 await Context.Set<TEntity>().Where(expression).ToListAsync();
        }
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }
        public Task<int> Execute(FormattableString interpolatedQueryString)
        {
            return Context.Database.ExecuteSqlInterpolatedAsync(interpolatedQueryString);
        }
        public TResult InTransaction<TResult>(Func<TResult> action, Action successAction = null, Action<Exception> exceptionAction = null)
        {
            var result = default(TResult);
            try
            {
                if (Context.Database.ProviderName.EndsWith("InMemory"))
                {
                    result = action();
                    SaveChanges();
                }
                else
                {
                    using (var tx = Context.Database.BeginTransaction())
                    {
                        try
                        {
                            result = action();
                            SaveChanges();
                            tx.Commit();
                        }
                        catch (Exception)
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }
                successAction?.Invoke();
            }
            catch (Exception ex)
            {
                if (exceptionAction == null)
                    throw;
                else
                    exceptionAction(ex);
            }
            return result;
        }
        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
                return await Context.Set<TEntity>().CountAsync();
            else
                return await Context.Set<TEntity>().CountAsync(expression);
        }
        public int GetCount(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
                return Context.Set<TEntity>().Count();
            else
                return Context.Set<TEntity>().Count(expression);
        }
    }
}
