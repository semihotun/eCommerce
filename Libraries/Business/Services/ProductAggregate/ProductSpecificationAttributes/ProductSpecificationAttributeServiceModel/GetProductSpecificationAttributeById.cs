using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel
{
    public class GetProductSpecificationAttributeById
    {
        public int productSpecificationAttributeId { get; set; }

        public GetProductSpecificationAttributeById(int productSpecificationAttributeId)
        {
            this.productSpecificationAttributeId = productSpecificationAttributeId;
        }
    }
}
