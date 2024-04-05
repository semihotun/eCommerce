namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class AllInsertPermutationCombinationReqModel
    {
        public AllInsertPermutationCombinationReqModel()
        {
            
        }
        public AllInsertPermutationCombinationReqModel(int productId)
        {
            ProductId = productId;
        }
        public int ProductId { get; set; }
    }
}
