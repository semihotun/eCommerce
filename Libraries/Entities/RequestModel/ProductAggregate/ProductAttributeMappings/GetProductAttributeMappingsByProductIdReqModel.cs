using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class GetProductAttributeMappingsByProductIdReqModel
    {
        public GetProductAttributeMappingsByProductIdReqModel()
        {
            
        }
        public GetProductAttributeMappingsByProductIdReqModel(Guid productId)
        {
            ProductId = productId;
        }
        public Guid ProductId { get; set; }
    }
}
