using System.Collections.Generic;
namespace Entities.Dtos.ProductDALModels
{
    public class Checkout
    {
        public IEnumerable<CheckoutProduct> CheckoutProductList { get; set; }
        public double AllProductTotalPrice { get; set; }
    }
}
