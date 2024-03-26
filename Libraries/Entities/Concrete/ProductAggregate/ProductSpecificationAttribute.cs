namespace Entities.Concrete.ProductAggregate
{
    public class ProductSpecificationAttribute : BaseEntity
    {
        public int ProductId { get; set; }
        public int AttributeTypeId { get; set; }
        public int SpecificationAttributeOptionId { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public int DisplayOrder { get; set; }
    }
}
