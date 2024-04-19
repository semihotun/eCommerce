using System;

namespace Entities.RequestModel.ProductAggregate.Products
{
    public class GetHomeProductDetailReqModel
    {
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
        public GetHomeProductDetailReqModel(Guid productId, Guid combinationId)
        {
            ProductId = productId;
            CombinationId = combinationId;
        }
        public GetHomeProductDetailReqModel()
        {
        }
    }
}
