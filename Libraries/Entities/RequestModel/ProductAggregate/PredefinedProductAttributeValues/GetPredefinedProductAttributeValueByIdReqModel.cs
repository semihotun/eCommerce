using System;

namespace Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues
{
    public class GetPredefinedProductAttributeValueByIdReqModel
    {
        public GetPredefinedProductAttributeValueByIdReqModel(Guid id)
        {
            Id = id;
        }
        public GetPredefinedProductAttributeValueByIdReqModel()
        {

        }
        public Guid Id { get; set; }
    }
}
