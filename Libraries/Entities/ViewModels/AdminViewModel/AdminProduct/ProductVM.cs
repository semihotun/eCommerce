using Core.SeedWork;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class ProductVM
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string ProductName { get; set; }
        public Guid? BrandId { get; set; } = Guid.Empty;
        public string BrandName { get; set; }
        public Guid? CategoryId { get; set; } = Guid.Empty;
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
        public Guid ProductSeoId { get; set; } = Guid.Empty;
        public Guid ProductAttributeId { get; set; } = Guid.Empty;
        public Guid ProductStockTypeId { get; set; } = Guid.Empty;
        public DateTime CreatedOnUtc { get; set; }
        public ProductShipmentInfo ProductShipmentInfo { get; set; }
        public ProductSeo ProductSeoModel { get; set; }
        public ProductAttributeMapping ProductAttributeMappingModel { get; set; }
        public ProductAttributeValue ProductAttributeValue { get; set; }
        public ProductSpecificationAttributeModel ProductSpecificationAttribute { get; set; }
        public ProductStockCreateOrUpdate ProductStock { get; set; }
        public IEnumerable<ProductAttributeMapping> ProductAttributeMappingList { get; set; }
        public List<ProductAttributeCombination> ProductAttiributeCombinationList { get; set; }
        public IEnumerable<SelectListItem> ProductStockTypeSelectList { get; set; }
        public IEnumerable<SelectListItem> CombinationSelectList { get; set; }
        public IEnumerable<SelectListItem> ProductAttributeSelectlist { get; set; }
        public IEnumerable<SelectListItem> SpeficationAttributeSelectList { get; set; }
        public IEnumerable<SelectListItem> BrandSelectListItems { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }
        public class ProductStockCreateOrUpdate : BaseEntity
        {
            public double? ProductPrice { get; set; }
            public double? ProductDiscount { get; set; }
            public int? ProductStockPiece { get; set; }
            public bool AllowOutOfStockOrders { get; set; }
            public int NotifyAdminForQuantityBelow { get; set; }
            public DateTime CreateTime { get; set; }
            public Guid ProductId { get; set; } = Guid.Empty;
            public Guid CombinationId { get; set; } = Guid.Empty;
            public string ProductName { get; set; }
        }
        public partial class ProductSpecificationAttributeModel : BaseEntity
        {
            public string SpecificationAttributeOptionName { get; set; }
            public string SpeficationAtributeTypeName { get; set; }
            public Guid ProductId { get; set; } = Guid.Empty;
            public Guid? AttributeTypeId { get; set; } = Guid.Empty;
            public int? SpecificationAttributeOptionId { get; set; }
            public bool AllowFiltering { get; set; }
            public bool ShowOnProductPage { get; set; }
            public int DisplayOrder { get; set; }
        }
    }
}
