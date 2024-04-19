using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class GetProductCombinationXmlReqModel
    {
        public GetProductCombinationXmlReqModel()
        {
            
        }
        public Guid ProductId { get; set; }
        public GetProductCombinationXmlReqModel(Guid productId)
        {
            ProductId = productId;
        }
    }
}
