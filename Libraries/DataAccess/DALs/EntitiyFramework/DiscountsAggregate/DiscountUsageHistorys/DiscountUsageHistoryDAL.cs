using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.DiscountsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountUsageHistorys
{
    public class DiscountUsageHistoryDAL : EfEntityRepositoryBase<DiscountUsageHistory, eCommerceContext>, IDiscountUsageHistoryDAL
    {
        public DiscountUsageHistoryDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
