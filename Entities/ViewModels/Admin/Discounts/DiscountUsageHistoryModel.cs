
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Admin
{
    public partial class DiscountUsageHistoryModel : BaseEntity
    { 
        public int DiscountId { get; set; }

        public int OrderId { get; set; }

        public virtual OrderModel Order { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public virtual DiscountModel Discount { get; set; }
    }
}
