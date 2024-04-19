using System;

namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class GetProductSpecificationAttributeByIdReqModel
    {
        public Guid ProductSpecificationAttributeId { get; set; }
        public GetProductSpecificationAttributeByIdReqModel()
        {
            
        }
        public GetProductSpecificationAttributeByIdReqModel(Guid productSpecificationAttributeId)
        {
            ProductSpecificationAttributeId = productSpecificationAttributeId;
        }
    }
}
