using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.DiscountsAggregate.DiscountUsageHistorys.DiscountUsageHistoryServiceModel
{
    public class GetAllDiscountUsageHistory
    {

        public int DiscountId { get; set; }
        public int Pageindex { get; set; }
        public int Pagesize { get; set; }

        public GetAllDiscountUsageHistory(int discountId = 0, int pageindex = 1, int pagesize = int.MaxValue)
        {
            DiscountId = discountId;
            Pageindex = pageindex;
            Pagesize = pagesize;
        }

        public GetAllDiscountUsageHistory()
        {
        }
    }
}
