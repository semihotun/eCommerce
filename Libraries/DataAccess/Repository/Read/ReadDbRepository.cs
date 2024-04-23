using Core.SeedWork;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace DataAccess.Repository.Read
{
    public class ReadDbRepository<TEntity> : IReadDbRepository<TEntity>
        where TEntity : BaseEntity, IEntity
    {
        private readonly ECommerceReadContext _readContext;
        public ReadDbRepository(ECommerceReadContext readContext)
        {
            _readContext = readContext;
        }
        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            var entity = await _readContext.Set<TEntity>().FindAsync(Id);
            if (entity?.IsDeleted == false)
            {
                return entity;
            }
            return null;
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return expression != null
                ? await _readContext.Query<TEntity>().FirstOrDefaultAsync(expression)
                : await _readContext.Query<TEntity>().FirstOrDefaultAsync();
        }
        public async Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> expression)
        {
            return expression != null
               ? await _readContext.Query<TEntity>().Where(expression).ToListAsync()
               : await _readContext.Query<TEntity>().ToListAsync();
        }
        public IQueryable<TEntity> Query()
        {
            return _readContext.Query<TEntity>().AsQueryable().Where(x => !x.IsDeleted);
        }
        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return expression == null
                ? await _readContext.Query<TEntity>().CountAsync()
                : await _readContext.Query<TEntity>().CountAsync(expression);
        }
        public int GetCount(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null
                ? _readContext.Query<TEntity>().Count()
                : _readContext.Query<TEntity>().Count(expression);
        }
    }
}
