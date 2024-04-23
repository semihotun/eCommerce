using System;

namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class GetProductSpecificationAttributeCountReqModel
    {
        public Guid ProductId { get; set; }
        public Guid SpecificationAttributeOptionId { get; set; }
        public GetProductSpecificationAttributeCountReqModel()
        {

        }
        public GetProductSpecificationAttributeCountReqModel(Guid productId, Guid specificationAttributeOptionId)
        {
            ProductId = productId;
            SpecificationAttributeOptionId = specificationAttributeOptionId;
        }
    }
}
