using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.OrderAggregate;
namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.OrderItems
{
    public class OrderItemDAL : EfEntityRepositoryBase<OrderItem, ECommerceContext>, IOrderItemDAL
    {
        public OrderItemDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
