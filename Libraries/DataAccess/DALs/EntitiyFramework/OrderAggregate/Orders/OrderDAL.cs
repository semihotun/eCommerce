using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.Orders
{
    public class OrderDAL : EfEntityRepositoryBase<Order, eCommerceContext>, IOrderDAL
    {
        public OrderDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
