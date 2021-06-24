namespace Entities.Concrete
{
    using eCommerce.Core.Entities;
    using System;
    using System.Collections.Generic;

    public class Product : BaseEntity 
    {

        public string ProductName { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string ProductContent { get; set; }
        public string ProductColor { get; set; }
        public int? Control { get; set; }
        public bool? ProductShow { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public int ProductStockTypeId { get; set; }
    }



  



}
