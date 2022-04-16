﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.DiscountsAggregate.DiscountBrands.DiscountBrandServiceModel
{
    public class GetAllDiscountBrand
    {
        public int DiscountId { get; set; }
        public int Pageindex { get; set; }
        public int PageSize { get; set; }

        public GetAllDiscountBrand(int discountId = 0, int pageindex = 1, int pageSize = int.MaxValue)
        {
            DiscountId = discountId;
            Pageindex = pageindex;
            PageSize = pageSize;
        }

        public GetAllDiscountBrand()
        {
        }
    }
}
