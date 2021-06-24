using Autofac;
using AutoMapper;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Helpers.AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace eCommerce.StartUpSettings
{
    public class Settings
    {
        public static void IdentitySettings(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<eCommerceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt => opt.UseRowNumberForPaging()));
            services.AddIdentity<MyUser, MyRole>()
             .AddEntityFrameworkStores<eCommerceContext>()
             .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Lockout.AllowedForNewUsers = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.SlidingExpiration = true;
            });

            services.AddAuthentication();
            //.AddFacebook(x =>
            //{
            //    x.AppId = Configuration["FacebookAppId"];
            //    x.AppSecret = Configuration["FacebookAppSecret"];
            //    x.CallbackPath = new PathString("/User/Hata");
            //})
            //.AddGoogle(x =>
            //{
            //    x.ClientId = Configuration["GoogleClientId"];
            //    x.ClientSecret = Configuration["GoogleClientSecret"];
        }

        public static void AutoMapperSettings(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthoMapperProfile());
                mc.AddProfile(new AdminAuthoMapperProfile());
            });
            IMapper mapper = AutoMapperConfig.Get().CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void SetupEmbeddedViewsForPlugins(IServiceCollection services, IEnumerable<Assembly> pluginAssemblies)
        {
            services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                foreach (var assembly in pluginAssemblies)
                {
                    var embeddedFile = new EmbeddedFileProvider(assembly);
                    options.FileProviders.Add(embeddedFile);
                }
            });
        }
        public static void RegisterMvc(IServiceCollection services, IEnumerable<Assembly> pluginAssemblies)
        {
            var mvcBuilder = services.AddMvc();
            foreach (var item in pluginAssemblies)
            {
                mvcBuilder.AddApplicationPart(item);
            }
            mvcBuilder.AddControllersAsServices();
        }

        public static IEnumerable<Assembly> GetPluginAssemblies()
        {
            var result=Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "Plugin.*.dll", SearchOption.AllDirectories)
                .Where(x => !x.Contains("Plugin.Base.dll"))
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);
            
            
            return result;
               
        }


    }

}
