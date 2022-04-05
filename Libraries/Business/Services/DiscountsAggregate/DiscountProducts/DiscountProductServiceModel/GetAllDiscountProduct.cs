using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.DiscountsAggregate.DiscountProducts.DiscountProductServiceModel
{
    public class GetAllDiscountProduct
    {

        public int DiscountId { get; set; }

        public int Pageindex { get; set; }

        public int Pagesize { get; set; }

        public GetAllDiscountProduct(int discountId = 0, int pageindex = 1, int pagesize = int.MaxValue)
        {
            DiscountId = discountId;
            Pageindex = pageindex;
            Pagesize = pagesize;
        }
    }
}
