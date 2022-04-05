using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class GetProductCombinationXml
    {
        public int ProductId { get; set; }

        public GetProductCombinationXml(int productId)
        {
            ProductId = productId;
        }
    }
}
