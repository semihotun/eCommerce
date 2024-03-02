using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.OrderAggregate;
namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.Orders
{
    public class OrderDAL : EfEntityRepositoryBase<Order, eCommerceContext>, IOrderDAL
    {
        public OrderDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
