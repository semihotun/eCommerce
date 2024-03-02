namespace Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel
{
    public class GetProductAttributeValues
    {
        public int ProductAttributeMappingId { get; set; }
        public GetProductAttributeValues(int productAttributeMappingId)
        {
            ProductAttributeMappingId = productAttributeMappingId;
        }
        public GetProductAttributeValues()
        {
        }
    }
}
