using eCommerce.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSeos
{
    public interface IProductSeoDAL : IEntityRepository<ProductSeo>
    {
    }
}
