using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel
{
    public class DeleteProductStock
    {
        public DeleteProductStock(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
