using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Abstract.Brands;
using Business.Abstract.Categories;
using Business.Abstract.Comments;
using Business.Abstract.Discounts;
using Business.Abstract.Products;
using Business.Abstract.Showcases;
using Business.Abstract.Sliders;
using Business.Abstract.Spefications;
using Business.Concrete;
using Business.Concrete.Brands;
using Business.Concrete.Categories;
using Business.Concrete.Comments;
using Business.Concrete.Discounts;
using Business.Concrete.Products;
using Business.Concrete.Showcases;
using Business.Concrete.Sliders;
using Business.Concrete.Spefications;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


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
            builder.RegisterType<ProductAttributeParser>().As<IProductAttributeParser>();
            builder.RegisterType<ProductAttributeService>().As<IProductAttributeService>();
            builder.RegisterType<ProductAttributeFormatter>().As<IProductAttributeFormatter>();
            builder.RegisterType<SpecificationAttributeService>().As<ISpecificationAttributeService>();
            builder.RegisterType<BrandService>().As<IBrandService>();
            builder.RegisterType<DiscountService>().As<IDiscountService>();
            builder.RegisterType<ShowcaseTypeService>().As<IShowcaseTypeService>();

            //builder.RegisterType<eCommerceContext>().AsSelf().As<DbContext>().InstancePerLifetimeScope();
            //builder.RegisterGeneric(typeof(EFQueryable<>)).As(typeof(IEfQueryable<>)).InstancePerLifetimeScope();

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

            //builder.RegisterType<ProductAttributeParser>().As<IProductAttributeParser>();
            //builder.RegisterType<ProductAttributeFormatter>().As<IProductAttributeFormatter>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
