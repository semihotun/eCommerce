using Entities.Concrete.BasketAggregate;
using System.Collections.Generic;
namespace Entities.Dtos.ProductDALModels
{
    public class GetCheckout
    {
        public GetCheckout(List<Basket> basket)
        {
            Basket = basket;
        }
        public GetCheckout()
        {
        }
        public List<Basket> Basket { get; set; }
    }
}
