namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class DeleteProductAttributeCombination
    {
        public DeleteProductAttributeCombination(int id)
        {
            Id = id;
        }
        public DeleteProductAttributeCombination()
        {
        }
        public int Id { get; set; }
    }
}
