namespace Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel
{
    public class DeleteProductAttributeMapping
    {
        public DeleteProductAttributeMapping(int ıd)
        {
            Id = ıd;
        }
        public DeleteProductAttributeMapping()
        {
        }
        public int Id { get; set; }
    }
}
