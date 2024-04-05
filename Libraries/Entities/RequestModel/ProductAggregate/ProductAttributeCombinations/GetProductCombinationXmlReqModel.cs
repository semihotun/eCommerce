namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class GetProductCombinationXmlReqModel
    {
        public GetProductCombinationXmlReqModel()
        {
            
        }
        public int ProductId { get; set; }
        public GetProductCombinationXmlReqModel(int productId)
        {
            ProductId = productId;
        }
    }
}
