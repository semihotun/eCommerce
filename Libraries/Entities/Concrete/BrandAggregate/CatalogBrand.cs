﻿namespace Entities.Concrete.BrandAggregate
{
    public class CatalogBrand : BaseEntity
    {
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
