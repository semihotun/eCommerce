namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel
{
    public class DeleteProductSpecificationAttribute
    {
        public DeleteProductSpecificationAttribute(int ıd)
        {
            Id = ıd;
        }
        public DeleteProductSpecificationAttribute()
        {
        }
        public int Id { get; set; }
    }
}
