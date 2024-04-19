using Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace DataAccess.Repository.Write
{
    public interface IWriteDbRepository<T> where T : class, IEntity
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        T Update(T entity);
        void Remove(T entity);
        void RemoveRange(List<T> entity);
        Task<List<T>> ToListAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> Query();
        Task<int> Execute(FormattableString interpolatedQueryString);
        Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null);
        int GetCount(Expression<Func<T, bool>> expression = null);
        Task<T> GetByIdAsync(Guid Id);
    }
}
