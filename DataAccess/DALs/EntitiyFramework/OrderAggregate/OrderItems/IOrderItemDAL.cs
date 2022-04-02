using eCommerce.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete.OrderAggregate;

namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.OrderItems
{
    public interface IOrderItemDAL : IEntityRepository<OrderItem>
    {

    }
}
