using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributes
{
    public partial class ProductAttributeDAL : EfEntityRepositoryBase<ProductAttribute, eCommerceContext>, IProductAttributeDAL
    {
        public ProductAttributeDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
