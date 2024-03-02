namespace Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel
{
    public class GetProductAttributeById
    {
        public GetProductAttributeById(int productAttributeId)
        {
            ProductAttributeId = productAttributeId;
        }
        public GetProductAttributeById()
        {
        }
        public int ProductAttributeId { get; set; }
    }
}
