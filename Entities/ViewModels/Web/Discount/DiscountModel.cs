namespace Entities.ViewModels.Web
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;

    public class DiscountModel : BaseEntity
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

        public DiscountTypeModel DiscountType
        {
            get => (DiscountTypeModel)DiscountTypeId;
            set => DiscountTypeId = (int)value;
        }

        public DiscountLimitationModel DiscountLimitation
        {
            get => (DiscountLimitationModel)DiscountLimitationId;
            set => DiscountLimitationId = (int)value;
        }
        public virtual ICollection<DiscountUsageHistoryModel> DiscountUsageHistory { get; set; }


        public List<SelectListItem> DiscountTypeList { get; set; }

        public List<SelectListItem> DiscountLimitationList { get; set; }


    }
}
