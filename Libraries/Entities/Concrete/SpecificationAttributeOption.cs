using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class SpecificationAttributeOption : BaseEntity, IEntity
    {
        public Guid SpecificationAttributeId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
