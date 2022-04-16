using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.DiscountsAggregate.Discounts.DiscountServiceModel
{
    public class GetDiscount
    {
        public int Id { get; set; }

        public GetDiscount(int ıd)
        {
            Id = ıd;
        }

        public GetDiscount()
        {
        }
    }
}
