using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.DiscountsAggregate
{
    public class DiscountUsageHistory : BaseEntity
    {
        public int DiscountId { get; set; }

        public int OrderId { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
