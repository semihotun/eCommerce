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
        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await Context.Set<TEntity>().FindAsync(Id);
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await Context.AddAsync(entity)).Entity;
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await Context.Set<TEntity>().AddRangeAsync(entity);
        }
        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            return entity;
        }
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(List<TEntity> entity)
        {
            Context.Set<TEntity>().RemoveRange(entity);
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
        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }
        public Task<int> Execute(FormattableString interpolatedQueryString)
        {
            return Context.Database.ExecuteSqlInterpolatedAsync(interpolatedQueryString);
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
