#region using
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter;
using Microsoft.AspNetCore.Http;
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
