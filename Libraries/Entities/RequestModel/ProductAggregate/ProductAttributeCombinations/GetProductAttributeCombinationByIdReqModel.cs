using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class GetProductAttributeCombinationByIdReqModel
    {
        public GetProductAttributeCombinationByIdReqModel()
        {
            
        }
        public GetProductAttributeCombinationByIdReqModel(Guid productAttributeCombinationId)
        {
            ProductAttributeCombinationId = productAttributeCombinationId;
        }
        public Guid ProductAttributeCombinationId { get; set; }
    }
}
