using Entities.Concrete.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels
{
    public  class GetCheckout
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
