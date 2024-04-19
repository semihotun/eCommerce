using Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace DataAccess.Repository.Read
{
    public interface IReadDbRepository<T> where T : class, IEntity
    {
        Task<List<T>> ToListAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> Query();
        Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null);
        int GetCount(Expression<Func<T, bool>> expression = null);
        Task<T> GetByIdAsync(Guid Id);
    }
}
