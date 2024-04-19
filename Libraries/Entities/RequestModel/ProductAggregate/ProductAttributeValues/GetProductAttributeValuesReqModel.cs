using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class GetProductAttributeValuesReqModel
    {
        public Guid ProductAttributeMappingId { get; set; }
        public GetProductAttributeValuesReqModel()
        {
            
        }
        public GetProductAttributeValuesReqModel(Guid productAttributeMappingId)
        {
            ProductAttributeMappingId = productAttributeMappingId;
        }
    }
}
