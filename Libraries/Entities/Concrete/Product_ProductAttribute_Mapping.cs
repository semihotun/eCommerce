using Core.SeedWork;
using System;
namespace Entities.Concrete
{
    public class ProductAttributeMapping : BaseEntity, IEntity
    {
        public Guid ProductId { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public Guid AttributeControlTypeId { get; set; }
        public int DisplayOrder { get; set; }
        public string DefaultValue { get; set; }
    }
}
