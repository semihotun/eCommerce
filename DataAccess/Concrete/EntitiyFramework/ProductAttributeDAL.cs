using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntitiyFramework
{
    public partial class ProductAttributeDAL: EfEntityRepositoryBase<ProductAttribute, eCommerceContext>, IProductAttributeDAL
    {
        public ProductAttributeDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
