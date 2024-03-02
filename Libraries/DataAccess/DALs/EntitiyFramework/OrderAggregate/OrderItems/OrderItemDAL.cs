using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.OrderAggregate;
namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.OrderItems
{
    public class OrderItemDAL : EfEntityRepositoryBase<OrderItem, eCommerceContext>, IOrderItemDAL
    {
        public OrderItemDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
