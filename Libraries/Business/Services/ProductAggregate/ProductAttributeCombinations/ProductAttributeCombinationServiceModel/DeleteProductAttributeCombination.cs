namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class DeleteProductAttributeCombination
    {
        public DeleteProductAttributeCombination(int ıd)
        {
            Id = ıd;
        }
        public DeleteProductAttributeCombination()
        {
        }
        public int Id { get; set; }
    }
}
