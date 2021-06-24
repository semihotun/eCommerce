using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class ProductStockTypeDAL : EfEntityRepositoryBase<ProductStockType, eCommerceContext>, IProductStockTypeDAL
    {
        public ProductStockTypeDAL(eCommerceContext context) : base(context)
        {
        }

    }

}
