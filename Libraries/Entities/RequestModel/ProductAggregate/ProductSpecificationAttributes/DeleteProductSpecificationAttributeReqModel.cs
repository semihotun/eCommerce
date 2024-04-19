using System;

namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class DeleteProductSpecificationAttributeReqModel
    {
        public DeleteProductSpecificationAttributeReqModel()
        {
            
        }
        public DeleteProductSpecificationAttributeReqModel(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
