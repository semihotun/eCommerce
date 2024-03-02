namespace Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel
{
    public class GetProductAttributeMappingsByProductId
    {
        public GetProductAttributeMappingsByProductId(int productId)
        {
            ProductId = productId;
        }
        public GetProductAttributeMappingsByProductId()
        {
        }
        public int ProductId { get; set; }
    }
}
