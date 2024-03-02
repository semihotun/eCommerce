using System;
namespace Entities.Concrete.DiscountsAggregate
{
    public class DiscountUsageHistory : BaseEntity
    {
        public int DiscountId { get; set; }
        public int OrderId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
