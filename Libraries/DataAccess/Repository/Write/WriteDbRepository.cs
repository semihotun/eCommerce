using Core.Extension;
using Core.SeedWork;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace DataAccess.Repository.Write
{
    public class WriteDbRepository<TEntity> : IWriteDbRepository<TEntity>
        where TEntity : BaseEntity, IEntity
    {
        private readonly ECommerceContext _writeContext;
        public WriteDbRepository(ECommerceContext writeContext)
        {
            _writeContext = writeContext;
        }
        public async Task<TEntity> GetByIdAsync(Guid Id)
        {
            var entity = await _writeContext.Set<TEntity>().FindAsync(Id);
            if (entity?.IsDeleted == false)
            {
                return entity;
            }
            return null;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _writeContext.AddAsync(entity)).Entity;
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await _writeContext.Set<TEntity>().AddRangeAsync(entity);
        }
        public TEntity Update(TEntity entity)
        {
            _writeContext.Update(entity);
            return entity;
        }
        public void Remove(TEntity entity)
        {
            entity.IsDeleted = true;
            _writeContext.Update(entity);
        }
        public void RemoveRange(List<TEntity> entity)
        {
            foreach (var item in entity)
            {
                item.IsDeleted = true;
                _writeContext.Update(entity);
            }
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>>? expression)
        {
            return expression != null
                ? await _writeContext.Query<TEntity>().FirstOrDefaultAsync(expression)
                : await _writeContext.Query<TEntity>().FirstOrDefaultAsync();
        }
        public async Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>>? expression )
        {
            return expression != null
                  ? await _writeContext.Query<TEntity>().Where(expression).ToListAsync()
                  : await _writeContext.Query<TEntity>().ToListAsync();
        }
        public IQueryable<TEntity> Query()
        {
            return _writeContext.Query<TEntity>();
        }
        public Task<int> Execute(FormattableString interpolatedQueryString)
        {
            return _writeContext.Database.ExecuteSqlInterpolatedAsync(interpolatedQueryString);
        }
        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? expression)
        {
            return expression == null
             ? await _writeContext.Query<TEntity>().CountAsync()
             : await _writeContext.Query<TEntity>().CountAsync(expression);
        }
        public int GetCount(Expression<Func<TEntity, bool>>? expression)
        {
            return expression == null
                ? _writeContext.Query<TEntity>().Count()
                : _writeContext.Query<TEntity>().Count(expression);
        }
    }
}
