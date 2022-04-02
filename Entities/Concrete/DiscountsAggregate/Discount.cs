namespace Entities.Concrete.DiscountsAggregate
{
    using System;
    using System.Collections.Generic;

    public class Discount : BaseEntity
    {
        public string Name { get; set; }

        public string AdminComment { get; set; }

        public int DiscountTypeId { get; set; }

        public bool UsePercentage { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal? MaximumDiscountAmount { get; set; }

        public DateTime? StartDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }

        public bool RequiresCouponCode { get; set; }

        public string CouponCode { get; set; }
        public int DiscountLimitationId { get; set; }

        public int LimitationTimes { get; set; }

        public int? MaximumDiscountedQuantity { get; set; }

        public bool AppliedToSubCategories { get; set; }

    }
}
