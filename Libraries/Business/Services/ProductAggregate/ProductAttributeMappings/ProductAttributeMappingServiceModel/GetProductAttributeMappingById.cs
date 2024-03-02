namespace Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel
{
    public class GetProductAttributeMappingById
    {
        public GetProductAttributeMappingById(int productAttributeMappingId)
        {
            ProductAttributeMappingId = productAttributeMappingId;
        }
        public GetProductAttributeMappingById()
        {
        }
        public int ProductAttributeMappingId { get; set; }
    }
}
