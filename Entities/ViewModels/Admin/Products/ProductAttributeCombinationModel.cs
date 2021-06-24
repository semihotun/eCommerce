using Entities.ViewModels.All;

namespace Entities.ViewModels.Admin
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

       
    public class ProductAttributeCombinationModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string AttributesXml { get; set; }

        public string Gtin { get; set; }
        public string Sku { get; set; }
        public string ManufacturerPartNumber { get; set; }

        public List<MappingAttrXml> AttributesXmlList { get; set; }
        public virtual ProductModel Product { get; set; }

        public IList<ProductAttributeCombinationModel> ProductAttributeCombinationsList { get; set; }
    }
}
