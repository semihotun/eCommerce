using System;

namespace Entities.RequestModel.ProductAggregate.Products
{
    public class GetProductDetailReqModel
    {
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
        public GetProductDetailReqModel(Guid productId, Guid combinationId)
        {
            ProductId = productId;
            CombinationId = combinationId;
        }
        public GetProductDetailReqModel()
        {
        }
    }
}
