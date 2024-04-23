using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class AllInsertPermutationCombinationReqModel
    {
        public AllInsertPermutationCombinationReqModel()
        {

        }
        public AllInsertPermutationCombinationReqModel(Guid productId)
        {
            ProductId = productId;
        }
        public Guid ProductId { get; set; }
    }
}
