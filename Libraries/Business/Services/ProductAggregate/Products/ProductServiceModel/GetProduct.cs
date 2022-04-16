using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.Products.ProductServiceModel
{
    public class GetProduct
    {
        public int Id { get; set; }

        public GetProduct(int ıd)
        {
            Id = ıd;
        }

        public GetProduct()
        {
        }
    }
}
