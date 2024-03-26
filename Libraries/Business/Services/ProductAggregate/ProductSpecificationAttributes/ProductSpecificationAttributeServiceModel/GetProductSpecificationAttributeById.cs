namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel
{
    public class GetProductSpecificationAttributeById
    {
        public int ProductSpecificationAttributeId { get; set; }
        public GetProductSpecificationAttributeById(int productSpecificationAttributeId)
        {
            this.ProductSpecificationAttributeId = productSpecificationAttributeId;
        }
        public GetProductSpecificationAttributeById()
        {
        }
    }
}
