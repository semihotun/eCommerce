namespace Entities.Concrete.ProductAggregate
{
    using System;
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string ProductContent { get; set; }
        public bool? ProductShow { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int ProductStockTypeId { get; set; }
        public string ProductNameUpper { get; set; }
    }
}
