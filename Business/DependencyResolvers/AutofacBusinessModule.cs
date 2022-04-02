#region using

using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Services.BrandAggregate.Brands;
using Business.Services.BrandAggregate.CatalogBrands;
using Business.Services.CategoriesAggregate.Categories;
using Business.Services.CommentsAggregate.Comments;
using Business.Services.DiscountsAggregate.Discounts;
using Business.Services.ProductAggregate.ProductAttributes;
using Business.Services.ProductAggregate.Products;
using Business.Services.ProductAggregate.ProductShipmentInfos;
using Business.Services.ProductAggregate.ProductStocks;
using Business.Services.ProductAggregate.ProductStockTypes;
using Business.Services.ShowcaseAggregate.ShowcaseServices;
using Business.Services.ShowcaseAggregate.ShowcaseTypes;
using Business.Services.SliderAggregate.Sliders;
using Business.Services.SpeficationAggregate.SpecificationAttributes;
using Castle.DynamicProxy;
using Core.Library.DAL.EntityFramework.Abstract;
using Core.Library.DAL.EntityFramework.Concrete;
using Core.Utilities.Interceptors;
using DataAccess.DALs.EntitiyFramework.AddressAggregate.Adress;
using DataAccess.DALs.EntitiyFramework.AddressAggregate.MyUserAdressess;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.CatalogBrands;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.CategorySpefications;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountBrands;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountCategorys;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountProducts;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountUsageHistorys;
using DataAccess.DALs.EntitiyFramework.OrderAggregate.OrderItems;
using DataAccess.DALs.EntitiyFramework.OrderAggregate.OrderNotes;
using DataAccess.DALs.EntitiyFramework.OrderAggregate.Orders;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.ProductPhotos;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.PredefinedProductAttributeValues;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributes;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSeos;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductShipmentInfos;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStockTypes;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowCaseProducts;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseTypes;
using DataAccess.DALs.EntitiyFramework.SliderAggregate.Sliders;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributes;
using Microsoft.AspNetCore.Http;
#endregion

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

            builder.RegisterType<SliderService>().As<ISliderService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ShowcaseService>().As<IShowcaseService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductAttributeService>().As<IProductAttributeService>();
            builder.RegisterType<ProductAttributeFormatter>().As<IProductAttributeFormatter>();
            builder.RegisterType<SpecificationAttributeService>().As<ISpecificationAttributeService>();
            builder.RegisterType<BrandService>().As<IBrandService>();
            builder.RegisterType<DiscountService>().As<IDiscountService>();
            builder.RegisterType<ShowcaseTypeService>().As<IShowcaseTypeService>();
            builder.RegisterType<ProductShipmentInfoDAL>().As<IProductShipmentInfoDAL>();
            builder.RegisterType<ProductShipmentInfoService>().As<IProductShipmentInfoService>();
            builder.RegisterType<ShowcaseTypeDAL>().As<IShowcaseTypeDAL>();
            builder.RegisterType<ProductDAL>().As<IProductDAL>();
            builder.RegisterType<AddressDAL>().As<IAddressDAL>();
            builder.RegisterType<BrandDAL>().As<IBrandDAL>();
            builder.RegisterType<CategoryDAL>().As<ICategoryDAL>();
            builder.RegisterType<CategorySpeficationDAL>().As<ICategorySpeficationDAL>();
            builder.RegisterType<CombinationPhotoDAL>().As<ICombinationPhotoDAL>();
            builder.RegisterType<CommentDAL>().As<ICommentDAL>();
            builder.RegisterType<DiscountBrandDAL>().As<IDiscountBrandDAL>();
            builder.RegisterType<DiscountCategoryDAL>().As<IDiscountCategoryDAL>();
            builder.RegisterType<DiscountDAL>().As<IDiscountDAL>();
            builder.RegisterType<DiscountProductDAL>().As<IDiscountProductDAL>();
            builder.RegisterType<DiscountUsageHistoryDAL>().As<IDiscountUsageHistoryDAL>();
            builder.RegisterType<MyUserAdressesDAL>().As<IMyUserAdressesDAL>();
            builder.RegisterType<OrderDAL>().As<IOrderDAL>();
            builder.RegisterType<OrderItemDAL>().As<IOrderItemDAL>();
            builder.RegisterType<OrderNoteDAL>().As<IOrderNoteDAL>();
            builder.RegisterType<PredefinedProductAttributeValueDAL>().As<IPredefinedProductAttributeValueDAL>();
            builder.RegisterType<ProductAttributeMappingDAL>().As<IProductAttributeMappingDAL>();
            builder.RegisterType<ProductAttributeCombinationDAL>().As<IProductAttributeCombinationDAL>();
            builder.RegisterType<ProductAttributeDAL>().As<IProductAttributeDAL>();
            builder.RegisterType<ProductAttributeValueDAL>().As<IProductAttributeValueDAL>();
            builder.RegisterType<ProductPhotoDAL>().As<IProductPhotoDAL>();
            builder.RegisterType<ProductSeoDAL>().As<IProductSeoDAL>();
            builder.RegisterType<ProductSpecificationAttributeDAL>().As<IProductSpecificationAttributeDAL>();
            builder.RegisterType<ShowcaseDAL>().As<IShowcaseDAL>();
            builder.RegisterType<ShowCaseProductDAL>().As<IShowCaseProductDAL>();
            builder.RegisterType<SliderDAL>().As<ISliderDAL>();
            builder.RegisterType<SpecificationAttributeDAL>().As<ISpecificationAttributeDAL>();
            builder.RegisterType<SpecificationAttributeOptionDAL>().As<ISpecificationAttributeOptionDAL>().SingleInstance();
            builder.RegisterType<ProductStockDAL>().As<IProductStockDAL>();
            builder.RegisterType<ProductStockService>().As<IProductStockService>();
            builder.RegisterType<ProductStockTypeDAL>().As<IProductStockTypeDAL>();
            builder.RegisterType<ProductStockTypeService>().As<IProductStockTypeService>();
            builder.RegisterType<CatalogBrandDAL>().As<ICatalogBrandDAL>();
            builder.RegisterType<CatalogBrandService>().As<ICatalogBrandService>();
 

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
