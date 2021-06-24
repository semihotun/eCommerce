namespace Entities.ViewModels.Web
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
    using Entities.Concrete;

    public class ProductModel
    {

        public int Id { get; set; }

        public string ProductName { get; set; }

        public double? ProductPrice { get; set; }

        public int? ProductStock { get; set; }

        public int? BrandId { get; set; }
        public string BrandName { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int? pageNumber { get; set; }

        public int? pageSize { get; set; }

        [UIHint("tinymce_full")]
        public string ProductContent { get; set; }

        public string ProductColor { get; set; }

        public int Control { get; set; }
        public bool ProductShow { get; set; }
        public string Tap { get; set; }

        public bool AllowOutOfStockOrders { get; set; }

        public string Gtin { get; set; }
        public string Sku { get; set; }

        public int? NotifyAdminForQuantityBelow { get; set; }
        public BrandModel BrandModel { get; set; }

        public CategoryModel CategoryModel { get; set; }

        public int ProductSeoId { get; set; }

        public ProductSeoModel ProductSeoModel { get; set; }

        public ProductPhotoModel ProductPhoto { get; set; }

        public ProductAttributeMappingModel ProductAttributeMappingModel { get; set; }

        public ProductAttributeCombinationModel ProductAttiributeCombinationModel { get; set; }

        public ProductCombinatioGeneration ProductCombinatioGeneration { get; set; }

        public List<ProductAttributeMappingModel> ProductAttributeMappingList { get; set; }

        public List<Comment> CommentList { get; set; }
        public List<ProductAttributeCombinationModel> ProductAttiributeCombinationList { get; set; }
        public List<ProductPhotoModel> ProductPhotoList { get; set; }

        public List<ProductSellModel> ProductSellList { get; set; }

        public List<ShoppingCartModel> ShoppingCartList { get; set; }

        public IPagedList<ProductModel> Productsortlist { get; set; }

        public IEnumerable<ProductModel> ProductGrid { get; set; }
        public ICollection<ProductSeo> ProductSeoCollection { get; set; }

        public List<SelectListItem> ProductAttributeSelectlist { get; set; }

        public int ProductAttributeId { get; set; }
        public virtual ICollection<ProductSpecificationAttributeModel> ProductSpecificationAttribute { get; set; }

        public virtual ProductSpecificationAttributeModel ProductSpecificationAttributeModel { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public virtual ICollection<DiscountProductModel> DiscountProduct { get; set; }

        public virtual ICollection<OrderItemModel> OrderItem { get; set; }
    }

}
