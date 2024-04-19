using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class DeleteProductAttributeValueReqModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public DeleteProductAttributeValueReqModel()
        {
            
        }
        public DeleteProductAttributeValueReqModel(Guid id, Guid productId)
        {
            Id = id;
            ProductId = productId;
        }
    }
}
