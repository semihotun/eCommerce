namespace Entities.Concrete
{
    using Core.SeedWork;
    using System;
    public class Product : BaseEntity, IEntity
    {
        public string ProductName { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? CategoryId { get; set; }
        public string ProductContent { get; set; }
        public bool? ProductShow { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public Guid ProductStockTypeId { get; set; }
        public string ProductNameUpper { get; set; }
    }
}
