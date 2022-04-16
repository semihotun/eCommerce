using Autofac;
using Business.DependencyResolvers;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.Email;
using Core.Utilities.Filter;
using Core.Utilities.Generate;
using Core.Utilities.IoC;
using Core.Utilities.Middlewares;
using Core.Utilities.Quartz;
using Core.Utilities.Swagger;
using eCommerce.StartUpSettings;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace eCommerce
{
    public class Startup
    {
        [Obsolete]
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }


        [Obsolete]
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment CurrentEnvironment { get; set; }

        public IConfiguration Configuration { get; }

        public IEnumerable<Assembly> PluginAssembly { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddCustomSwaggerGen();
            services.AddDbContext(Configuration);
            services.AddDependencyResolvers(new ICoreModule[] { new CoreModule()});
            services.AutoMapperSettings();
            services.AddHttpContextAccessor();

            #region TempData

            services.AddMemoryCache();
            services.AddSession();

            #endregion

            #region Identity  

            services.AddIdentitySettings(Configuration);
            services.AddUserIdentitySettings(Configuration);

            #endregion

            #region Jobs

            services.UseQuartz();
            services.AddJobList();

            #endregion

            #region PluginSetting

            ApiGenerator.GenerateApi();
            var pluginAssemblies = PluginExtension.GetPluginAssemblies();
            PluginExtension.RegisterMvc(services, pluginAssemblies);
            PluginExtension.SetupEmbeddedViewsForPlugins(services, pluginAssemblies);
            services.AddPluginStaticFileProvier(CurrentEnvironment);
            PluginAssembly = pluginAssemblies;

            #endregion

            services.AddRazorPages().AddNewtonsoftJson();
            services.AddMvc(options =>
            {
                options.Filters.AddService<ValidationFilter>();
            }).AddFluentValidation();

            services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                 options.JsonSerializerOptions.IgnoreNullValues = true;
             });
            services.AddRazorPages();

   

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //Plugin Autofac Modullerini inject ettiðim Kýsým
            #region Moduleinject

            var pluginAssemblies = PluginAssembly;

            builder.RegisterAssemblyModules(pluginAssemblies.ToArray());

            #endregion

            //Projenin AutoFacModule'ü
            builder.RegisterModule(new AutofacBusinessModule());
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "eCommerce v1");
                });
            }
            else if (env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "eCommerce v1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            //app.UseCookiePolicy();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "Plugin",
                   pattern: "{plugin:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });


            app.AddPluginStaticFileProvier(PluginAssembly);
            ServiceTool.ServiceProvider = app.ApplicationServices;
        }




    }
}
