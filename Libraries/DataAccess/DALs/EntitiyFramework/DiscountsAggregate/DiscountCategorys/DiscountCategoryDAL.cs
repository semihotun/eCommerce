using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.DiscountsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountCategorys
{
    public class DiscountCategoryDAL : EfEntityRepositoryBase<DiscountCategory, eCommerceContext>, IDiscountCategoryDAL
    {
        public DiscountCategoryDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
