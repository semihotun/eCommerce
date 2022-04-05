namespace Entities.Concrete.ProductAggregate
{
    using System;
    using System.Collections.Generic;


    public partial class ProductAttributeValue : BaseEntity
    {
        public int ProductAttributeMappingId { get; set; }
        public string Name { get; set; }
        public string ColorSquaresRgb { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }

    }
}
