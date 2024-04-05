namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class GetProductAttributeMappingByIdReqModel
    {
        public GetProductAttributeMappingByIdReqModel()
        {
            
        }
        public GetProductAttributeMappingByIdReqModel(int productAttributeMappingId)
        {
            ProductAttributeMappingId = productAttributeMappingId;
        }
        public int ProductAttributeMappingId { get; set; }
    }
}
