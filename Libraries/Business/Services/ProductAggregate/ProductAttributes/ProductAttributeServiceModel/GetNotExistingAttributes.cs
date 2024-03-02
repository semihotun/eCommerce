namespace Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel
{
    public class GetNotExistingAttributes
    {
        public GetNotExistingAttributes(int[] attributeId)
        {
            AttributeId = attributeId;
        }
        public GetNotExistingAttributes()
        {
        }
        public int[] AttributeId { get; set; }
    }
}
