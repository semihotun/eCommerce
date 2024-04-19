using System;

namespace Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues
{
    public class GetPredefinedProductAttributeValuesReqModel
    {
        public GetPredefinedProductAttributeValuesReqModel(Guid productAttributeId)
        {
            ProductAttributeId = productAttributeId;
        }
        public GetPredefinedProductAttributeValuesReqModel()
        {
            
        }
        public Guid ProductAttributeId { get; set; }
    }
}
