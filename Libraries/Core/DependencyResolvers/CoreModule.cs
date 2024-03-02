using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Library.Business.AdminAggregate.AdminAuths;
using Core.Library.Business.AdminAggregate.AdminServices;
using Core.Library.DAL.EntityFramework.AdminAuths;
using Core.Utilities.Email;
using Core.Utilities.Filter;
using Core.Utilities.IoC;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<Stopwatch>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            serviceCollection.AddTransient<IAdminUserDAL, AdminUserDAL> ();
            serviceCollection.AddTransient<IAdminAuthService, AdminAuthService>();
            serviceCollection.AddTransient<IAdminService, AdminService>();
            serviceCollection.AddTransient<ITokenHelper, JwtHelper>();
            serviceCollection.AddTransient<ValidationFilter>();
            serviceCollection.AddTransient<IMailService, MailManager>();
            serviceCollection.AddTransient<FileLogger>();
            serviceCollection.AddTransient<MsSqlLogger>();
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
                if(classInterface != null)
                     serviceCollection.TryAdd(ServiceDescriptor.Transient(classInterface, item));
            }
        }
    }
}
