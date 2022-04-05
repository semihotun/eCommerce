using System;
using System.Collections.Generic;
using System.Text;
using eCommerce.Core.DataAccess;
using Entities.Concrete.ProductAggregate;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStockTypes
{
    public interface IProductStockTypeDAL : IEntityRepository<ProductStockType>
    {
    }
}
