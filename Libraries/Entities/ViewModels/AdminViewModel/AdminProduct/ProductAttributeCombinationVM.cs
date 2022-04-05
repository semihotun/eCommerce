using Entities.Concrete.ProductAggregate;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class ProductAttributeCombinationVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string AttributesXml { get; set; }

        public string Gtin { get; set; }
        public string Sku { get; set; }
        public string ManufacturerPartNumber { get; set; }

        public List<MappingAttrXml> AttributesXmlList { get; set; }
        public virtual Product Product { get; set; }

        public IList<ProductAttributeCombination> ProductAttributeCombinationsList { get; set; }
    }
}
