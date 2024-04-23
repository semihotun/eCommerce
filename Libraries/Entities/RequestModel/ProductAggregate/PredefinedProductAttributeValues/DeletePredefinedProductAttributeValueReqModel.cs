using System;

namespace Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues
{
    public class DeletePredefinedProductAttributeValueReqModel
    {
        public Guid Id { get; set; }
        public DeletePredefinedProductAttributeValueReqModel()
        {

        }
        public DeletePredefinedProductAttributeValueReqModel(Guid id)
        {
            Id = id;
        }
    }
}
