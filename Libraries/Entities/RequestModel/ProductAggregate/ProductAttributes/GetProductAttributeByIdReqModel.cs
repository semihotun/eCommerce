using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class GetProductAttributeByIdReqModel
    {
        public GetProductAttributeByIdReqModel()
        {

        }
        public GetProductAttributeByIdReqModel(Guid productAttributeId)
        {
            ProductAttributeId = productAttributeId;
        }
        public Guid ProductAttributeId { get; set; }
    }
}
