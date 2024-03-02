using System.Collections.Generic;
namespace Entities.DTO.Product
{
    public class Checkout
    {
        public IEnumerable<CheckoutProduct> CheckoutProductList { get; set; }
        public double AllProductTotalPrice { get; set; }
    }
}
