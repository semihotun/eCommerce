using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel
{
    public class GetProductSpecificationAttributeCount
    {
        public int ProductId { get; set; }
        public int SpecificationAttributeOptionId { get; set; }

        public GetProductSpecificationAttributeCount(int productId = 0, int specificationAttributeOptionId = 0)
        {
            ProductId = productId;
            SpecificationAttributeOptionId = specificationAttributeOptionId;
        }
    }
}
