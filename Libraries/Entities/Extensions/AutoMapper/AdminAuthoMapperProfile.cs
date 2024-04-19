using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.ProductDALModels;
using Entities.Dtos.ShowcaseDALModels;
using Entities.RequestModel.AdminAggregate.AdminAuths;
using Entities.RequestModel.BasketAggregate.Baskets;
using Entities.RequestModel.BrandAggregate.Brands;
using Entities.RequestModel.CategoriesAggregate.Categories;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using Entities.RequestModel.CommentsAggregate.Comments;
using Entities.RequestModel.PhotoAggregate.ProductPhotos;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using Entities.RequestModel.ProductAggregate.Products;
using Entities.RequestModel.ProductAggregate.ProductShipmentInfos;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
using Entities.RequestModel.SliderAggregate.Sliders;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Entities.ViewModels.AdminViewModel.Showcase;
using Entities.ViewModels.AdminViewModel.SpeficationAttributes;
namespace Entities.Extensions.AutoMapper
{
    public class AdminAuthoMapperProfile : Profile
    {
        public AdminAuthoMapperProfile()
        {
            //Kontrol edilip Silinecek
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
            CreateMap<SpecificationAttributeOption, SpecificationAttributeOption>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ProductAttribute, ProductAttribute>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ProductAttributeValue, ProductAttributeValue>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<Category, Category>().ForMember(x => x.Id, mo => mo.Ignore());
            CreateMap<ShowCaseDTO, ShowCase>();
            CreateMap<Product, ProductDataTableJson>().ReverseMap();
            CreateMap<ShowCaseCreateOrUpdateVM, ShowCase>().ReverseMap();
            CreateMap<SpecificationAttributeVM, SpecificationAttribute>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<ProductStockCreateOrUpdateVM, ProductStock>().ReverseMap();
            CreateMap<ProductAttributeCombinationVM, ProductAttributeCombination>().ReverseMap();
            //Vm
            CreateMap<ShowCaseCreateOrUpdateVM, InsertShowcaseReqModel>().ReverseMap();
            CreateMap<UpdateSpecificationAttributeOptionReqModel, SpecificationAttributeOptionVM>().ReverseMap();
            CreateMap<InsertSpecificationAttributeOptionReqModel, SpecificationAttributeOption>().ReverseMap();
            CreateMap<UpdateSpecificationAttributeOptionReqModel, SpecificationAttributeOptionVM>().ReverseMap();
            CreateMap<SpecificationAttributeOptionVM, SpecificationAttributeOption>().ReverseMap();
            CreateMap<SpecificationAttributeVM, UpdateSpecificationAttributeReqModel>().ReverseMap();
            CreateMap<ShowCaseCreateOrUpdateVM, UpdateShowcaseReqModel>().ReverseMap();
            CreateMap<ShowCaseCreateOrUpdateVM, InsertProductShowcaseReqModel>().ReverseMap();
            CreateMap<ShowCaseProduct, InsertProductShowcaseReqModel>().ReverseMap();
            CreateMap<ShowCaseDTO, UpdateShowcaseReqModel>().ReverseMap();
            CreateMap<ShowCaseProduct, InsertProductShowcaseReqModel>().ReverseMap();
            CreateMap<ProductAttributeCombinationVM, UpdateProductAttributeCombinationReqModel>().ReverseMap();
            CreateMap<InsertProductAttributeReqModel, ProductAttribute>().ReverseMap();
            //BasketService
            CreateMap<UpdateBasketProductPieceReqModel, Basket>().ReverseMap();
            CreateMap<DeleteBasketProductReqModel, Basket>().ReverseMap();
            CreateMap<UpdateBasketProductPieceReqModel, Basket>().ReverseMap();
            //BrandService
            CreateMap<UpdateBrandReqModel, Brand>().ReverseMap();
            CreateMap<AddBrandReqModel, Brand>().ReverseMap();
            CreateMap<DeleteBrandReqModel, Brand>().ReverseMap();
            //CategoryService
            CreateMap<InsertCategoryReqModel, Category>().ReverseMap();
            CreateMap<UpdateCategoryReqModel, Category>().ReverseMap();
            CreateMap<DeleteCategoryReqModel, Category>().ReverseMap();
            //CategorySpeficationService
            CreateMap<InsertCategorySpeficationReqModel, CategorySpefication>().ReverseMap();
            CreateMap<UpdateCategorySpeficationReqModel, CategorySpefication>().ReverseMap();
            CreateMap<DeleteCategorySpeficationReqModel, CategorySpefication>().ReverseMap();
            //CommentService
            CreateMap<CommentApproveReqModel, Comment>().ReverseMap();
            CreateMap<AddCommentReqModel, Comment>().ReverseMap();
            CreateMap<UpdateCommentReqModel, Comment>().ReverseMap();
            CreateMap<DeleteCommentReqModel, Comment>().ReverseMap();
            //ProductPhotoService
            CreateMap<AddProductPhotoReqModel, ProductPhoto>().ReverseMap();
            CreateMap<DeleteProductPhotoReqModel, ProductPhoto>().ReverseMap();
            //PredefinedProductAttributeValuesService
            CreateMap<InsertPredefinedProductAttributeValueReqModel, PredefinedProductAttributeValue>().ReverseMap();
            CreateMap<UpdatePredefinedProductAttributeValueReqModel, PredefinedProductAttributeValue>().ReverseMap();
            CreateMap<DeletePredefinedProductAttributeValueReqModel, PredefinedProductAttributeValue>().ReverseMap();
            //ProductAttributeCombinationsService
            CreateMap<InsertProductAttributeCombinationReqModel, ProductAttributeCombination>().ReverseMap();
            CreateMap<UpdateProductAttributeCombinationReqModel, ProductAttributeCombination>().ReverseMap();
            CreateMap<DeleteProductAttributeCombinationReqModel, ProductAttributeCombination>().ReverseMap();
            //ProductAttributeMappingsService
            CreateMap<InsertProductAttributeMappingReqModel, ProductAttributeMapping>().ReverseMap();
            CreateMap<InsertProductAttributeMappingReqModel, ProductAttributeMapping>().ReverseMap();
            CreateMap<UpdateProductAttributeMappingReqModel, ProductAttributeMapping>().ReverseMap();
            CreateMap<DeleteProductAttributeMappingReqModel, ProductAttributeMapping>().ReverseMap();
            //ProductAttributeService
            CreateMap<UpdateProductAttributeReqModel, ProductAttribute>().ReverseMap();
            CreateMap<InsertProductAttributeReqModel, ProductAttribute>().ReverseMap();
            CreateMap<DeleteProductAttributeReqModel, ProductAttribute>().ReverseMap();
            //ProductAttributeValueService
            CreateMap<UpdateProductAttributeValueReqModel, ProductAttributeValue>().ReverseMap();
            CreateMap<InsertOrUpdateProductAttributeValueReqModel, UpdateProductAttributeValueReqModel>().ReverseMap();
            CreateMap<InsertOrUpdateProductAttributeValueReqModel, InsertProductAttributeValueReqModel>().ReverseMap();
            CreateMap<InsertProductAttributeValueReqModel, ProductAttributeValue>().ReverseMap();
            CreateMap<DeleteProductAttributeValueReqModel, ProductAttributeValue>().ReverseMap();
            //ProductServiceService
            CreateMap<CreateOrUpdateProductReqModel, AddProductReqModel>().ReverseMap();
            CreateMap<CreateOrUpdateProductReqModel, UpdateProductReqModel>().ReverseMap();
            CreateMap<UpdateProductReqModel, Product>().ReverseMap();
            CreateMap<AddProductReqModel, Product>().ReverseMap();
            CreateMap<DeleteProductReqModel, Product>().ReverseMap();
            //ProductShipmentInfoService
            CreateMap<AddOrUpdateProductShipmentInfoReqModel, UpdateProductShipmentInfoReqModel>().ReverseMap();
            CreateMap<AddOrUpdateProductShipmentInfoReqModel, AddProductShipmentInfoReqModel>().ReverseMap();
            CreateMap<AddProductShipmentInfoReqModel, ProductShipmentInfo>().ReverseMap();
            CreateMap<UpdateProductShipmentInfoReqModel, ProductShipmentInfo>().ReverseMap();
            //ProductSpecificationAttributeService
            CreateMap<InsertProductSpecificationAttributeReqModel, ProductSpecificationAttribute>().ReverseMap();
            CreateMap<UpdateProductSpecificationAttributeReqModel, ProductSpecificationAttribute>().ReverseMap();
            CreateMap<DeleteProductSpecificationAttributeReqModel, ProductSpecificationAttribute>().ReverseMap();
            //ProductStockService
            CreateMap<AddProductStockReqModel, ProductStock>().ReverseMap();
            CreateMap<DeleteProductStockReqModel, ProductStock>().ReverseMap();
            //ShowCaseProductService
            CreateMap<InsertProductShowcaseReqModel, ShowCaseProduct>().ReverseMap();
            //ShowcaseService
            CreateMap<InsertShowcaseReqModel, ShowCase>().ReverseMap();
            CreateMap<UpdateShowcaseReqModel, ShowCase>().ReverseMap();
            //SliderService
            CreateMap<InsertSliderReqModel, Slider>().ReverseMap();
            CreateMap<UpdateSliderReqModel, Slider>().ReverseMap();
            CreateMap<DeleteSliderReqModel, Slider>().ReverseMap();
            //SpecificationAttributeOptionService
            CreateMap<InsertSpecificationAttributeOptionReqModel, SpecificationAttributeOption>().ReverseMap();
            CreateMap<UpdateSpecificationAttributeOptionReqModel, SpecificationAttributeOption>().ReverseMap();
            CreateMap<DeleteSpecificationAttributeOptionReqModel, SpecificationAttributeOption>().ReverseMap();
            //SpecificationAttributeService
            CreateMap<InsertSpecificationAttributeReqModel, SpecificationAttribute>().ReverseMap();
            CreateMap<UpdateSpecificationAttributeReqModel, SpecificationAttribute>().ReverseMap();
            CreateMap<DeleteSpecificationAttributeReqModel, SpecificationAttribute>().ReverseMap();
            //AdminAuth
            CreateMap<AddReqModel, AdminUser>().ReverseMap();
        }
    }
}
