using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.OrderAggregate;
namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.Orders
{
    public class OrderDAL : EfEntityRepositoryBase<Order, ECommerceContext>, IOrderDAL
    {
        public OrderDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
