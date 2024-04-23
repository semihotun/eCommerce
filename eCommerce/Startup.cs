#region using
using Autofac;
using Business.Extension;
using Core.Extension;
using Core.Utilities.Caching;
using Core.Utilities.Cookie;
using Core.Utilities.DependencyResolvers;
using Core.Utilities.Identity;
using Core.Utilities.IoC;
using Core.Utilities.Swagger;
using DataAccess.Extension;
using eCommerce.Extensions;
using Entities.Extensions.AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
#endregion
namespace eCommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }
        private IWebHostEnvironment CurrentEnvironment { get; }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext(Configuration);
            services.AddCustomSwaggerGen();
            services.AutoMapperSettings();
            services.AddHttpContextAccessor();
            services.AddRedis(Configuration);
            services.AddIdentitySettings(Configuration);
            services.ConfigureApplicationCookie(CurrentEnvironment);
            services.AddRazorPages().AddNewtonsoftJson();
            services.AddMvc().AddFluentValidation().ConfigureApiBehaviorOptions(x => x.SuppressModelStateInvalidFilter = true);
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });
            services.AddControllersWithViews(options => options.Filters.Add(new TokenBearerFilter()));
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacBusinessModule(AssembliesExtension.GetAllAssemblies()));
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Error/Error/Index");
            app.UseHsts();
            app.UseStatusCodePagesWithReExecute("/Error/Error/Index");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "Plugin",
                   pattern: "{plugin:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToAreaController("Index", "Home", "Web");
            });
            ServiceTool.ServiceProvider = app.ApplicationServices;
        }
    }
}
