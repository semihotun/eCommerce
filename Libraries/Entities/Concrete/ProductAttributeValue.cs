using Core.SeedWork;
using System;
namespace Entities.Concrete
{
#nullable enable
    public class ProductAttributeValue : BaseEntity, IEntity
    {
        public Guid ProductAttributeMappingId { get; set; }
        public string? Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
