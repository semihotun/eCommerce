using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Web
{
    public class DiscountBrandModel :BaseEntity
    {

        public int DiscountId { get; set; }

        public int BrandId { get; set; }

        public virtual BrandModel Brand { get; set; }

        public virtual DiscountModel Discount { get; set; }
    }
}
