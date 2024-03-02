namespace Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel
{
    public class GetProductAttributeValueById
    {
        public GetProductAttributeValueById(int productAttributeValueId)
        {
            ProductAttributeValueId = productAttributeValueId;
        }
        public GetProductAttributeValueById()
        {
        }
        public int ProductAttributeValueId { get; set; }
    }
}
