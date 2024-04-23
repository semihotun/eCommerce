using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class GetProductAttributeMappingByIdReqModel
    {
        public GetProductAttributeMappingByIdReqModel()
        {

        }
        public GetProductAttributeMappingByIdReqModel(Guid productAttributeMappingId)
        {
            ProductAttributeMappingId = productAttributeMappingId;
        }
        public Guid ProductAttributeMappingId { get; set; }
    }
}
