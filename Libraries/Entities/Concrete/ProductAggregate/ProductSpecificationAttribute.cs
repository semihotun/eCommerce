using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.ProductAggregate
{
    public partial class ProductSpecificationAttribute : BaseEntity
    {

        public int ProductId { get; set; }

        public int AttributeTypeId { get; set; }

        public int SpecificationAttributeOptionId { get; set; }

        public bool AllowFiltering { get; set; }

        public bool ShowOnProductPage { get; set; }

        public int DisplayOrder { get; set; }
    }
}
