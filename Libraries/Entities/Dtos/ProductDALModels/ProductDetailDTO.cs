using Entities.Concrete;
using Entities.Concrete.CustomerUserAggregate;
using Entities.Concrete.PhotoAggregate;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductSpecificationAttributeDALModels;
using Entities.Dtos.ShowcaseDALModels;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using System;
using System.Collections.Generic;
namespace Entities.Dtos.ProductDALModels
{
    public class ProductDetailDTO
    {
        public Product ProductModel { get; set; }
        #region Brand
        public Brand BrandModel { get; set; }
        public class Brand
        {
            public Concrete.BrandAggregate.Brand BrandInfo { get; set; }
        }
        #endregion
        #region Category
        public Category CategoryModel { get; set; }
        public class Category
        {
            public Concrete.CategoriesAggregate.Category CategoryInfo { get; set; }
        }
        #endregion
        #region ProductPhoto
        public IEnumerable<ProductPhoto> ProductPhotoList { get; set; }
        #endregion
        #region Comment
        public class CommentInfo
        {
            public string CommentTitle { get; set; }
            public string CommentText { get; set; }
            public int Productid { get; set; }
            public int UserId { get; set; }
            public bool IsApproved { get; set; }
            public DateTime CreatedOnUtc { get; set; }
            public int Rating { get; set; }
        }
        public class Comment
        {
            public Concrete.CommentsAggregate.Comment CommentInfo { get; set; }
            public CustomerUser User { get; set; }
        }
        public IEnumerable<Comment> CommentList { get; set; }
        #endregion
        #region Mapping
        public IEnumerable<ProductAttributeMapping> ProductAttributeMappingList { get; set; }
        public class ProductAttributeMapping
        {
            public int Id { get; set; }
            public int ProductAttributeId { get; set; }
            public string TextPrompt { get; set; }
            public bool IsRequired { get; set; }
            public int AttributeControlTypeId { get; set; }
            public int DisplayOrder { get; set; }
            public IEnumerable<ProductAttributeValue> ProductAttributeValueList { get; set; }
        }
        #endregion
        #region ProductAttributeCombination 
        public IEnumerable<ProductAttributeCombination> ProductAttributeCombinationList { get; set; }
        public class ProductAttributeCombination
        {
            public ProductStock ProductStockModel { get; set; }
            public int Id { get; set; }
            public string AttributesXml { get; set; }
            public string Gtin { get; set; }
            public string Sku { get; set; }
            public string ManufacturerPartNumber { get; set; }
        }
        #endregion
        public IEnumerable<ProductSpecificationAttributeDTO> ProductSpecificationAttributeList { get; set; }
        public IEnumerable<ShowCaseProductDTO.Product> AnotherProductList { get; set; }
        public ProductStock ProductStock { get; set; }
        public IEnumerable<ProductAttributeCombinationVM> AttrCombinationList { get; set; }
    }
}
