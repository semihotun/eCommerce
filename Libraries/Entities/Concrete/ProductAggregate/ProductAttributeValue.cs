namespace Entities.Concrete.ProductAggregate
{
#nullable enable
    public class ProductAttributeValue : BaseEntity
    {
        public int ProductAttributeMappingId { get; set; }
        public string? Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
