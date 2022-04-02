using Autofac;
using AutoMapper;
using Core.Library;
using Core.Utilities.Security.Encyption;
using Entities.Concrete;
using Entities.Helpers.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Core.Utilities.Security.Jwt;
using DataAccess.Context;

namespace eCommerce.StartUpSettings
{
    public static class UserIdentityExtension
    {
        public static void AddUserIdentitySettings(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddIdentity<MyUser, MyRole>()
             .AddEntityFrameworkStores<eCommerceContext>()
             .AddDefaultTokenProviders();
            services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromHours(3));
            services.Configure<Microsoft.AspNetCore.Identity.IdentityOptions>(options =>
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

        
    


    }

}
