using eCommerce.Core.DataAccess;
using Entities.Concrete.OrderAggregate;
namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.Orders
{
    public interface IOrderDAL : IEntityRepository<Order>
    {
    }
}
