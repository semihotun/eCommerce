namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class GetProductAttributeCombinationBySkuReqModel
    {
        public GetProductAttributeCombinationBySkuReqModel()
        {

        }
        public GetProductAttributeCombinationBySkuReqModel(string sku)
        {
            Sku = sku;
        }
        public string Sku { get; set; }
    }
}
