using Entities.Concrete;
using System.Collections.Generic;
namespace Entities.RequestModel.ProductAggregate.Products
{
    public class GetCheckoutReqModel
    {
        public GetCheckoutReqModel(List<Basket> basket)
        {
            Basket = basket;
        }
        public GetCheckoutReqModel()
        {
        }
        public List<Basket> Basket { get; set; }
    }
}
