using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Library.Business.Abstract;
using Core.Library.Business.Concrete;
using Core.Library.DAL.EntityFramework.Abstract;
using Core.Library.DAL.EntityFramework.Concrete;
using Core.Utilities.IoC;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<Stopwatch>();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            serviceCollection.AddTransient<IAdminUserDAL, AdminUserDAL> ();
            serviceCollection.AddTransient<IAdminAuthService, AdminAuthService>();
            serviceCollection.AddTransient<IAdminService, AdminService>();
            serviceCollection.AddTransient<ITokenHelper, JwtHelper>();


            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembliesFilter = assemblies.Where(
                 x => x.ManifestModule.Name == "Business.dll" ||
                 x.ManifestModule.Name == "DataAccess.dll"
                 );
            var assemblyClass = assembliesFilter.SelectMany(x => x.GetTypes()
                .Where(x => x.IsClass == true && x.IsPublic == true &&
                (x.Name.ToLowerInvariant().Contains("service") || x.Name.ToLowerInvariant().Contains("dal")) &&
                (x.FullName.Contains("Business.Services") || x.FullName.Contains("DataAccess.DALs.EntitiyFramework"))
            ));
            var assemblyInterFace = assembliesFilter.SelectMany(x => x.GetTypes()
                   .Where(x => x.IsInterface == true && x.IsPublic == true &&
                   (x.Name.ToLowerInvariant().Contains("service") || x.Name.ToLowerInvariant().Contains("dal")) &&
                   (x.FullName.Contains("Business.Services") || x.FullName.Contains("DataAccess.DALs.EntitiyFramework"))
            ));

            foreach (var item in assemblyClass)
            {
                var classInterface = assemblyInterFace.Where(x => x.Name == "I" + item.Name).FirstOrDefault();

                serviceCollection.TryAdd(ServiceDescriptor.Transient(classInterface, item));
            }

        }
    }
}
