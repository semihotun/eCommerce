using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class GetProductDetailMappingJsonReqModel
    {
        public Guid ProductId { get; set; }

        public GetProductDetailMappingJsonReqModel(Guid productId)
        {
            ProductId = productId;
        }
    }
}
