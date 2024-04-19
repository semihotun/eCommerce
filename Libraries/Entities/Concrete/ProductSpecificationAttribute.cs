using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class ProductSpecificationAttribute : BaseEntity, IEntity
    {
        public Guid ProductId { get; set; }
        public Guid AttributeTypeId { get; set; }
        public Guid SpecificationAttributeOptionId { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public int DisplayOrder { get; set; }
    }
}
