namespace Entities.Concrete.ProductAggregate
{
    public class ProductAttributeMapping : BaseEntity
    {
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public int AttributeControlTypeId { get; set; }
        public int DisplayOrder { get; set; }
        public string DefaultValue { get; set; }
    }
}
