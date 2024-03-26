namespace Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel
{
    public class DeleteProductAttributeValue
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DeleteProductAttributeValue(int id, int productId)
        {
            Id = id;
            ProductId = productId;
        }
        public DeleteProductAttributeValue()
        {
        }
    }
}
