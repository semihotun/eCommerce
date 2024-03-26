namespace Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel
{
    public class DeleteProductAttributeMapping
    {
        public DeleteProductAttributeMapping(int id)
        {
            Id = id;
        }
        public DeleteProductAttributeMapping()
        {
        }
        public int Id { get; set; }
    }
}
