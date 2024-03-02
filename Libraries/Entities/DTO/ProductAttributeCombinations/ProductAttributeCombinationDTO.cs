using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
namespace Entities.DTO.ProductAttributeCombinations
{
    public class ProductAttributeCombinationDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string AttributesXml { get; set; }
        public List<MappingAttrXml> AttributesXmlList { get; set; }
        public ProductStock ProductStockModel { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public string Sku { get; set; }
        public string ManufacturerPartNumber { get; set; }
        public string Gtin { get; set; }
        public decimal? OverriddenPrice { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public virtual Concrete.ProductAggregate.Product Product { get; set; }
        public IList<ProductAttributeCombinationDTO> productAttributeCombinationsList { get; set; }
    }
}
