#region using
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Module = Autofac.Module;
#endregion
namespace Core.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        private readonly Assembly[] _assemblies;
        public AutofacBusinessModule(Assembly[] assemblies)
        {
            _assemblies = assemblies;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterAssemblyTypes(_assemblies).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
