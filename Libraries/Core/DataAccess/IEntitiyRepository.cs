using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        T Update(T entity);
        void Remove(T entity);
        void RemoveRange(List<T> entity);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> Query();
        Task<int> Execute(FormattableString interpolatedQueryString);
        Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null);
        int GetCount(Expression<Func<T, bool>> expression = null);
        Task<T> GetByIdAsync(int Id);
    }
}
