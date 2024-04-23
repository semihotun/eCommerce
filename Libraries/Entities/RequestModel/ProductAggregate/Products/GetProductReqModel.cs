using System;

namespace Entities.RequestModel.ProductAggregate.Products
{
    public class GetProductReqModel
    {
        public Guid Id { get; set; }
        public GetProductReqModel()
        {

        }
        public GetProductReqModel(Guid id)
        {
            Id = id;
        }
    }
}
