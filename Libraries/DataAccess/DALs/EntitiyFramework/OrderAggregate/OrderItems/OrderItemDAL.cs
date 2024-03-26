using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
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
