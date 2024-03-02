using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.DiscountsAggregate;
namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountProducts
{
    public class DiscountProductDAL : EfEntityRepositoryBase<DiscountProduct, eCommerceContext>, IDiscountProductDAL
    {
        public DiscountProductDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
