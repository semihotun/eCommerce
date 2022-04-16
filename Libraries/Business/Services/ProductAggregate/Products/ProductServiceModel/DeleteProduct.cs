using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.Products.ProductServiceModel
{
    public class DeleteProduct
    {
        public DeleteProduct(int ıd)
        {
            Id = ıd;
        }

        public DeleteProduct()
        {
        }

        public int Id { get; set; }

    }
}
