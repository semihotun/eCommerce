using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Product
{
    public class Checkout
    {
        public IEnumerable<CheckoutProduct> CheckoutProductList { get; set; }
        public double AllProductTotalPrice { get; set; }
    }
}
