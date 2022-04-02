using Autofac;
using Business.DependencyResolvers;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.Email;
using Core.Utilities.Filter;
using Core.Utilities.Generate;
using Core.Utilities.IoC;
using Core.Utilities.Quartz;
using eCommerce.StartUpSettings;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.ToString());
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "eCommerce", Version = "v2"});
            });

            services.AddDbContext(Configuration);
            services.AddIdentitySettings(Configuration);

            #region PluginSetting

            var pluginAssemblies = PluginExtension.GetPluginAssemblies();
            PluginExtension.RegisterMvc(services, pluginAssemblies);
            PluginExtension.SetupEmbeddedViewsForPlugins(services, pluginAssemblies);
            services.AddPluginStaticFileProvier(CurrentEnvironment);
            PluginAssembly = pluginAssemblies;

            #endregion

            services.AddRazorPages().AddNewtonsoftJson();
            //services.AddControllersWithViews(x => x.SuppressAsyncSuffixInActionNames = false).AddRazorRuntimeCompilation();

            services.AddTransient<ValidationFilter>();
            services.AddMvc(options =>
            {
                options.Filters.AddService<ValidationFilter>();
            }).AddFluentValidation();

            services.AddTransient<IMailService,MailManager>();
            services.AddTransient<FileLogger>();
            services.AddTransient<MsSqlLogger>();
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            services.AddUserIdentitySettings(Configuration);
            services.AutoMapperSettings();

            services.UseQuartz();
            services.AddJobList();

         
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
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "eCommerce v1");
                });
               ApiGenerator.GenerateApi();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
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
