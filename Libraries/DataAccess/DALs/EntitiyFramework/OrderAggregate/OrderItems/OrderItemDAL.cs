using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.OrderItems
{
    public class OrderItemDAL : EfEntityRepositoryBase<OrderItem, eCommerceContext>, IOrderItemDAL
    {
        public OrderItemDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
