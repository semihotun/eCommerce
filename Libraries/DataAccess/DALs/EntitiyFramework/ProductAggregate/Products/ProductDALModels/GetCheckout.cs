using Entities.Concrete.BasketAggregate;
using System.Collections.Generic;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels
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
