using Core.Utilities.Email;
using Core.Utilities.IoC;
using Core.Utilities.Logging.SeriLog;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
namespace Core.Utilities.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddScoped<Stopwatch>();
            serviceCollection.AddScoped<IActionContextAccessor, ActionContextAccessor>();
            serviceCollection.AddTransient<IMailService, MailManager>();
            serviceCollection.AddTransient<MsSqlLogger>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembliesFilter = assemblies.Where(
                 x => x.ManifestModule.Name == "Business.dll"
                 );
            var assemblyClass = assembliesFilter.SelectMany(x => x.GetTypes()
                .Where(x => x.IsClass && x.IsPublic &&
                (x.Name.Contains("service", StringComparison.InvariantCultureIgnoreCase)&&
                (x.FullName.Contains("Business.Services")))
            ));
            var assemblyInterFace = assembliesFilter.SelectMany(x => x.GetTypes()
                   .Where(x => x.IsInterface && x.IsPublic &&
                   (x.Name.Contains("service", StringComparison.InvariantCultureIgnoreCase)&&
                   (x.FullName.Contains("Business.Services")))
            ));
            foreach (var item in assemblyClass)
            {
                var classInterface = assemblyInterFace.FirstOrDefault(x => x.Name == "I" + item.Name);
                if (classInterface != null)
                    serviceCollection.TryAdd(ServiceDescriptor.Transient(classInterface, item));
            }
        }
    }
}
