using Entities.Concrete;
using Entities.Dtos.ProductAttributeMappingDALModels;
using System;
using System.Collections.Generic;
namespace Entities.Dtos.ProductAttributeCombinationDALModels
{
    public class ProductAttributeCombinationDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string AttributesXml { get; set; }
        public List<MappingAttrXml> AttributesXmlList { get; set; }
        public ProductStock ProductStockModel { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public string Sku { get; set; }
        public string ManufacturerPartNumber { get; set; }
        public string Gtin { get; set; }
        public decimal? OverriddenPrice { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public virtual Product Product { get; set; }
        public IList<ProductAttributeCombinationDTO> productAttributeCombinationsList { get; set; }
    }
}
