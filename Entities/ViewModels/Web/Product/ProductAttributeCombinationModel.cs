namespace Entities.ViewModels.Web
{
    using Entities.Concrete;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class ProductAttributeCombinationModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string AttributesXml { get; set; }
        public List<Entities.ViewModels.All.MappingAttrXml> AttributesXmlList { get; set; }
        public ProductStock ProductStockModel { get; set; }

        public bool AllowOutOfStockOrders { get; set; }

        [StringLength(400)]
        public string Sku { get; set; }

        [StringLength(400)]
        public string ManufacturerPartNumber { get; set; }

        [StringLength(400)]
        public string Gtin { get; set; }

        public decimal? OverriddenPrice { get; set; }

        public int NotifyAdminForQuantityBelow { get; set; }

        public virtual Product Product { get; set; }

        public IList<ProductAttributeCombinationModel> productAttributeCombinationsList { get; set; }
    }
}
