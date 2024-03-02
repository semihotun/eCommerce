namespace Entities.Concrete.ProductAggregate
{
    using System;
    using System.Collections.Generic;
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
