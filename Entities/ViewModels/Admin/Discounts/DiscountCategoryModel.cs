
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Admin
{
    public class DiscountCategoryModel: BaseEntity
    {

        public int DiscountId { get; set; }

        public int CategoryId { get; set; }


        public virtual CategoryModel Category { get; set; }

        public virtual DiscountModel Discount { get; set; }
    }
}
