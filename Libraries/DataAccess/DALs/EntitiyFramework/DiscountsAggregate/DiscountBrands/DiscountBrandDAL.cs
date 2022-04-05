using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.DiscountsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountBrands
{
    public class DiscountBrandDAL : EfEntityRepositoryBase<DiscountBrand, eCommerceContext>, IDiscountBrandDAL
    {
        public DiscountBrandDAL(eCommerceContext context) : base(context)
        {
        }

    }
}
