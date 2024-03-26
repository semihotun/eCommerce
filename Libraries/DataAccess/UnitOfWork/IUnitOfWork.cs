using System;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<T> BeginTransaction<T>(Func<Task<T>> action);
    }
}
