using Core.Library;
using Core.Utilities.Identity;
using DataAccess.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace eCommerce.StartUpSettings
{
    public static class UserIdentityExtension
    {
        public static void AddUserIdentitySettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<MyUser, MyRole>()
             .AddEntityFrameworkStores<eCommerceContext>()
             .AddErrorDescriber<CustomIdentityErrorDescriber>()
             .AddDefaultTokenProviders();
            services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromHours(3));
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
    }
}
