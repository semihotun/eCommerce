namespace Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    




    public  class ProductAttributeCombination : BaseEntity
    {
        public int ProductId { get; set; }
        public string AttributesXml { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public string ManufacturerPartNumber { get; set; }
    }
}
