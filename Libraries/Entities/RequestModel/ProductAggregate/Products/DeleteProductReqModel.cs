using System;

namespace Entities.RequestModel.ProductAggregate.Products
{
    public class DeleteProductReqModel
    {
        public DeleteProductReqModel()
        {

        }
        public DeleteProductReqModel(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
