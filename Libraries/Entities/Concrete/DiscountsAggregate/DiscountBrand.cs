using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.Concrete.DiscountsAggregate
{
    public class DiscountBrand : BaseEntity
    {
        public int DiscountId { get; set; }
        public int BrandId { get; set; }
    }
}
