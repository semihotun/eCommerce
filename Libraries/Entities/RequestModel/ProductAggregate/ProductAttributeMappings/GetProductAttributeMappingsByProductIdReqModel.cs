namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class GetProductAttributeMappingsByProductIdReqModel
    {
        public GetProductAttributeMappingsByProductIdReqModel()
        {
            
        }
        public GetProductAttributeMappingsByProductIdReqModel(int productId)
        {
            ProductId = productId;
        }
        public int ProductId { get; set; }
    }
}
