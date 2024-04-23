using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class DeleteProductAttributeReqModel
    {
        public Guid Id { get; set; }
        public DeleteProductAttributeReqModel()
        {

        }
        public DeleteProductAttributeReqModel(Guid id)
        {
            Id = id;
        }
    }
}
