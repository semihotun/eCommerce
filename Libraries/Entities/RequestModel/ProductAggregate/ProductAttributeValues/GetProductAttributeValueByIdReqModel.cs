using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class GetProductAttributeValueByIdReqModel
    {
        public GetProductAttributeValueByIdReqModel()
        {
            
        }
        public GetProductAttributeValueByIdReqModel(Guid productAttributeValueId)
        {
            ProductAttributeValueId = productAttributeValueId;
        }
        public Guid ProductAttributeValueId { get; set; }
    }
}
