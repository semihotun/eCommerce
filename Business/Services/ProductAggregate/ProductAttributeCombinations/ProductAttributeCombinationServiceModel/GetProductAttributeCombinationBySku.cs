using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class GetProductAttributeCombinationBySku
    {
        public GetProductAttributeCombinationBySku(string sku)
        {
            Sku = sku;
        }

        public string Sku { get; set; }
    }
}
