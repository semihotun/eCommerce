using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.DiscountsAggregate;
namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountBrands
{
    public class DiscountBrandDAL : EfEntityRepositoryBase<DiscountBrand, eCommerceContext>, IDiscountBrandDAL
    {
        public DiscountBrandDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
