using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class GetProductAttributeCombinationById
    {
        public GetProductAttributeCombinationById(int productAttributeCombinationId)
        {
            ProductAttributeCombinationId = productAttributeCombinationId;
        }

        public GetProductAttributeCombinationById()
        {
        }

        public int ProductAttributeCombinationId { get; set; }
    }
}
