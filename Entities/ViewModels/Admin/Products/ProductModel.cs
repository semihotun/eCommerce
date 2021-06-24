using Entities.Concrete;
using Entities.ViewModels.Admin.Products.ProductStock;

namespace Entities.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using X.PagedList;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Entities.ViewModels.Web.SpecifationAttr;

    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        [UIHint("tinymce_full")]
        public string ProductContent { get; set; }
        public string ProductColor { get; set; }
        public int Control { get; set; }
        public bool ProductShow { get; set; }
        public string Tap { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public int ProductSeoId { get; set; }
        public int ProductAttributeId { get; set; }
        public int ProductStockTypeId { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public ProductShipmentInfo ProductShipmentInfo { get; set; }
        public ProductSeoModel ProductSeoModel { get; set; }
        public ProductAttributeMappingModel ProductAttributeMappingModel { get; set; }
        public ProductAttributeValue ProductAttributeValue { get; set; }
        public ProductSpecificationAttributeModel ProductSpecificationAttribute { get; set; }
        public ProductStockCreateOrUpdate ProductStock { get; set; }
        public List<ProductAttributeMappingModel> ProductAttributeMappingList { get; set; }
        public List<ProductAttributeCombinationModel> ProductAttiributeCombinationList { get; set; }

        public IEnumerable<SelectListItem> ProductStockTypeSelectList { get; set; }
        public IEnumerable<SelectListItem> CombinationSelectList { get; set; }
        public IEnumerable<SelectListItem> ProductAttributeSelectlist { get; set; }
        public IEnumerable<SelectListItem> SpeficationAttributeSelectList { get; set; }
        public IEnumerable<SelectListItem> BrandSelectListItems { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }


    }

}
