

using Entities.Concrete;
using Entities.DTO.Product;
using Entities.ViewModels.Admin;
using Entities.ViewModels.All;
using AutoMapper;
using Entities.DTO.ShowCase;
using Entities.ViewModels.Admin.Products;
using Entities.ViewModels.Admin.Products.ProductStock;

namespace Entities.Helpers.AutoMapper
{
    public class AdminAuthoMapperProfile : Profile
    {
        public AdminAuthoMapperProfile()
        {

            CreateMap<Product, ProductDataTableJson>();

            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();
            CreateMap<Product, ProductListModel>();



            //Farklı Dosya Taşı Başla
            CreateMap<ProductShipmentInfo, ProductShipmentInfo>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<Product, Product>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<SpecificationAttribute, SpecificationAttribute>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<Brand, Brand>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<ProductAttributeMapping, ProductAttributeMapping>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<PredefinedProductAttributeValue, PredefinedProductAttributeValue>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<ProductSeo, ProductSeo>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<Slider, Slider>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<ShowCase, ShowCase>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<ShowCaseProduct, ShowCaseProduct>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<CombinationPhoto, CombinationPhoto>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<Discount, Discount>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<DiscountBrand, DiscountBrand>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<DiscountCategory, DiscountCategory>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<DiscountProduct, DiscountProduct>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<DiscountUsageHistory, DiscountUsageHistory>().ForMember(x => x.Id, mo => mo.Ignore()); 
            CreateMap<SpecificationAttributeOption, SpecificationAttributeOption>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ProductAttribute, ProductAttribute>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ProductAttributeValue, ProductAttributeValue>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<Category, Category>().ForMember(x => x.Id, mo => mo.Ignore());


            //Farklı Dosya Taşı Bitiş



            CreateMap<ProductStock, ProductStockCreateOrUpdate>();
            CreateMap<ProductStockCreateOrUpdate, ProductStock>();


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

            CreateMap<CommentModel, Comment>();
            CreateMap<Comment, CommentModel>();

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

            //CreateMap<ProductAttributeValue, ProductAttributeValueModel>();
            CreateMap<ProductAttributeValueModel, ProductAttributeValue>();

            CreateMap<ProductAttributeValue, ProductAttributeValueModel>();

            CreateMap<ProductSeo, ProductSeoModel>();
            CreateMap<ProductSeoModel, ProductSeo>();

            CreateMap<SliderModel, Slider>();
            CreateMap<Slider, SliderModel>();

            CreateMap<ShowCase, ShowCaseModel>();
            CreateMap<ShowCaseDTO, ShowCase>();
            CreateMap<ShowCase, ShowCaseDTO>();
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
