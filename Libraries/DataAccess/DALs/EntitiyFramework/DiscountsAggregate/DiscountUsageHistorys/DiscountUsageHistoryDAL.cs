using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.DiscountsAggregate;
namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountUsageHistorys
{
    public class DiscountUsageHistoryDAL : EfEntityRepositoryBase<DiscountUsageHistory, eCommerceContext>, IDiscountUsageHistoryDAL
    {
        public DiscountUsageHistoryDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
