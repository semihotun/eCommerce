namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class AllInsertPermutationCombination
    {
        public AllInsertPermutationCombination(int productId)
        {
            ProductId = productId;
        }
        public int ProductId { get; set; }
    }
}
