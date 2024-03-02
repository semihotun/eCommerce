using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.DiscountsAggregate;
namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountCategorys
{
    public class DiscountCategoryDAL : EfEntityRepositoryBase<DiscountCategory, eCommerceContext>, IDiscountCategoryDAL
    {
        public DiscountCategoryDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
