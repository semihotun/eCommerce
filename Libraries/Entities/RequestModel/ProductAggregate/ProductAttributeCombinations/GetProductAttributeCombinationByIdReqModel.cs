namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class GetProductAttributeCombinationByIdReqModel
    {
        public GetProductAttributeCombinationByIdReqModel()
        {
            
        }
        public GetProductAttributeCombinationByIdReqModel(int productAttributeCombinationId)
        {
            ProductAttributeCombinationId = productAttributeCombinationId;
        }
        public int ProductAttributeCombinationId { get; set; }
    }
}
