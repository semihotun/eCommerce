namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel
{
    public class DeleteProductSpecificationAttribute
    {
        public DeleteProductSpecificationAttribute(int id)
        {
            Id = id;
        }
        public DeleteProductSpecificationAttribute()
        {
        }
        public int Id { get; set; }
    }
}
