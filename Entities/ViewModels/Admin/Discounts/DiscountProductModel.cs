
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Admin
{
    public class DiscountProductModel: BaseEntity
    {

        public int DiscountId { get; set; }

        public int ProductId { get; set; }

        public virtual DiscountModel Discount { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}
