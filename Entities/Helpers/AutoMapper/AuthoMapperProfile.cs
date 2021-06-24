using Entities.Concrete;
using Entities.ViewModels.All;
using Entities.ViewModels.Web;
using Entities.ViewModels.Web.SpecifationAttr;
using AutoMapper;
using Entities.DTO.Product;

namespace Entities.Helpers.AutoMapper
{
    public class AuthoMapperProfile : Profile
    {
        public AuthoMapperProfile()
        {




            CreateMap<ProductDetailDTO.ProductAttributeCombination, ProductAttributeCombinationModel>().ReverseMap();

            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();

            CreateMap<SpecificationAttribute, SpecificationAttributeModel>();
            CreateMap<SpecificationAttributeModel, SpecificationAttribute>();

            CreateMap<SpecificationAttributeOption, SpecificationAttributeOptionModel>();
            CreateMap<SpecificationAttributeOptionModel, SpecificationAttributeOption>();

            CreateMap<ProductSpecificationAttribute, ProductSpecificationAttributeModel>();
            CreateMap<ProductSpecificationAttributeModel, ProductSpecificationAttribute>();

            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();

            CreateMap<CategorySpeficationModel, CategorySpefication>();
            CreateMap<CategorySpefication, CategorySpeficationModel>();


            CreateMap<CatalogFilterModel, CategorySpefication>();
            CreateMap<CategorySpefication, CatalogFilterModel>();

            CreateMap<SpecificationAttribute, CatalogSpecificationAttributeModel>();
            CreateMap<CatalogSpecificationAttributeModel, SpecificationAttribute>();

            CreateMap<SpecificationAttributeOption, CatalogSpecificationAttributeOptionModel>();
            CreateMap<CatalogSpecificationAttributeOptionModel, SpecificationAttributeOption>();


            CreateMap<ProductPhotoModel, ProductPhoto>();
            CreateMap<ProductPhoto, ProductPhotoModel>();

            CreateMap<ProductAttribute, ProductAttributeModel>();
            CreateMap<ProductAttributeModel, ProductAttribute>();


            CreateMap<Brand, BrandModel>();
            CreateMap<BrandModel, Brand>();

            CreateMap<ProductAttributeMappingModel, ProductAttributeMapping>();
            CreateMap<ProductAttributeMapping, ProductAttributeMappingModel>();

            CreateMap<MappingAttrModel, MappingAttrXml>();
            CreateMap<MappingAttrXml, MappingAttrModel>();

            CreateMap<PredefinedProductAttributeValue, PredefinedProductAttributeValueModel>();
            CreateMap<PredefinedProductAttributeValueModel, PredefinedProductAttributeValue>();

            CreateMap<ProductAttributeCombinationModel, ProductAttributeCombination>();
            CreateMap<ProductAttributeCombination, ProductAttributeCombinationModel>();


            CreateMap<ProductAttributeValueModel, ProductAttributeValue>();
            CreateMap<ProductAttributeValue, ProductAttributeValueModel>();

            CreateMap<ProductSeo, ProductSeoModel>();
            CreateMap<ProductSeoModel, ProductSeo>();

            CreateMap<SliderModel, Slider>();
            CreateMap<Slider, SliderModel>();

            CreateMap<ShowCase, ShowCaseModel>();
            CreateMap<ShowCaseModel, ShowCase>();

            CreateMap<ShowCaseProduct, ShowCaseProductModel>();
            CreateMap<ShowCaseProductModel, ShowCaseProduct>();

            CreateMap<CombinationPhoto, CombinationPhotoModel>();
            CreateMap<CombinationPhotoModel, CombinationPhoto>();

            CreateMap<Discount, DiscountModel>();
            CreateMap<DiscountModel, Discount>();

            CreateMap<DiscountProduct, DiscountProductModel>();
            CreateMap<DiscountProductModel, DiscountProduct>();

            CreateMap<DiscountBrand, DiscountBrandModel>();
            CreateMap<DiscountBrandModel, DiscountBrand>();

            CreateMap<DiscountCategory, DiscountCategoryModel>();
            CreateMap<DiscountCategoryModel, DiscountCategory>();

            CreateMap<DiscountUsageHistory, DiscountUsageHistoryModel>();
            CreateMap<DiscountUsageHistoryModel, DiscountUsageHistory>();


        }
    }
}
