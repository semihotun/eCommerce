namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class GetProductAttributeCombinationBySku
    {
        public GetProductAttributeCombinationBySku(string sku)
        {
            Sku = sku;
        }
        public GetProductAttributeCombinationBySku()
        {
        }
        public string Sku { get; set; }
    }
}
