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
using System;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;
#endregion
namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<ProductAttributeFormatter>().As<IProductAttributeFormatter>();
            builder.RegisterType<ProductAttributeFormatter>().As<IProductAttributeFormatter>();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
