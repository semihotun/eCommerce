using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.Extensions.DependencyInjection;

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

            serviceCollection.AddTransient<IAdminUserDAL, AdminUserDAL> ();
            serviceCollection.AddTransient<IAdminAuthService, AdminAuthService>();
            serviceCollection.AddTransient<IAdminService, AdminService>();
            serviceCollection.AddTransient<ITokenHelper, JwtHelper>();

        }
    }
}
