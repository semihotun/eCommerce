namespace Entities.Concrete.SpeficationAggregate
{
    public class SpecificationAttributeOption : BaseEntity
    {
        public int SpecificationAttributeId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
