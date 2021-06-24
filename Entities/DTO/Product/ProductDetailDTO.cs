using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTO.ProductMapping;
using Entities.DTO.ShowCase;
using Entities.ViewModels.Admin;
using BaseEntity = Entities.Concrete.BaseEntity;

namespace Entities.DTO.Product
{
    public class ProductDetailDTO
    {
        public Concrete.Product ProductModel { get; set; }


        #region Brand
        public Brand BrandModel { get; set; }
        public class Brand
        {
            public Entities.Concrete.Brand BrandInfo { get; set; }
            public List<DiscountBrand> DiscountBrandList { get; set; }
        }

        #endregion

        #region Category
        public Category CategoryModel { get; set; }
        public class Category
        {
            public Entities.Concrete.Category CategoryInfo { get; set; }
            public List<DiscountCategory> DiscountBrandList { get; set; }

        }
        #endregion

        #region ProductPhoto
        public IEnumerable<Entities.Concrete.ProductPhoto> ProductPhotoList { get; set; }

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
            public Entities.Concrete.Comment CommentInfo { get; set; }
            public MyUser User { get; set; }
        }
        public List<Comment> CommentList { get; set; }
        #endregion

        #region Mapping
        public List<ProductAttributeMapping> ProductAttributeMappingList { get; set; }
        public class ProductAttributeMapping
        {
            public int Id { get; set; }
            public int ProductAttributeId { get; set; }
            public string TextPrompt { get; set; }
            public bool IsRequired { get; set; }
            public int AttributeControlTypeId { get; set; }
            public int DisplayOrder { get; set; }
            public List<ProductAttributeValue> ProductAttributeValueList { get; set; }

        }

        #endregion

        #region ProductAttributeCombination 

        public List<ProductAttributeCombination> ProductAttributeCombinationList { get; set; }
        public  class ProductAttributeCombination {

            public ProductStock ProductStockModel { get; set; }
            public int Id { get; set; }
            public string AttributesXml { get; set; }
            public string Gtin { get; set; }
            public string Sku { get; set; }
            public string ManufacturerPartNumber { get; set; }           
        }
        #endregion

        public List<ProductSpecificationAttributeDTO> ProductSpecificationAttributeList { get; set; }
        public List<ShowCaseProductDTO.Product> AnotherProductList { get; set; }
        public ProductStock ProductStock { get; set; }
        public List<ProductAttributeCombinationModel> AttrCombinationList { get; set; }
    }
}
