namespace Entities.Dtos.ProductAttributeMappingDALModels
{
    public class GetProductDetailMappingJson
    {
        public GetProductDetailMappingJson(int productId)
        {
            ProductId = productId;
        }
        public GetProductDetailMappingJson()
        {
        }
        public int ProductId { get; set; }
    }
}
