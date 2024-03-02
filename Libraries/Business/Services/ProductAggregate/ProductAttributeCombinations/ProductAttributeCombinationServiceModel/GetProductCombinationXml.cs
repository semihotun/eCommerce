namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class GetProductCombinationXml
    {
        public int ProductId { get; set; }
        public GetProductCombinationXml(int productId)
        {
            ProductId = productId;
        }
        public GetProductCombinationXml()
        {
        }
    }
}
