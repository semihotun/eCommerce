using AutoMapper;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Extensions;
using Entities.Concrete;
using Entities.Helpers.AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using eCommerce.StartUpSettings;
using Autofac;
using Business.DependencyResolvers;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Core.Library;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.Encyption;

namespace eCommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        public IEnumerable<Assembly> PluginAssembly { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<eCommerceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt => opt.UseRowNumberForPaging()));
            services.AddDbContext<CoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), opt => opt.UseRowNumberForPaging()));

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });


            var pluginAssemblies =Settings.GetPluginAssemblies();
            Settings.RegisterMvc(services, pluginAssemblies);
            Settings.SetupEmbeddedViewsForPlugins(services, pluginAssemblies);


            services.AddRazorPages().AddNewtonsoftJson();
            services.AddControllersWithViews(x => x.SuppressAsyncSuffixInActionNames = false).AddRazorRuntimeCompilation();
            services.AddMvc().AddFluentValidation();

            Settings.IdentitySettings(services, Configuration);
            Settings.AutoMapperSettings(services);

  
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddTransient<Extensions.IEmailSender, EmailSender>();
            services.AddTransient<FileLogger>();
            services.AddTransient<MsSqlLogger>();
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });

            
            PluginAssembly = pluginAssemblies;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var pluginAssemblies = PluginAssembly;
            builder.RegisterAssemblyModules(pluginAssemblies.ToArray());
            builder.RegisterModule(new AutofacBusinessModule());

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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


            var plugin = PluginAssembly.Where(x => x.ManifestModule.Name.Contains("Views") == false);
            var  staticOptions=new List<StaticFileOptions>();
            foreach (var item in plugin)
            {
                var pluginFolderName = item.ManifestModule.Name.Replace(".dll", "");
                var option = new StaticFileOptions();
                option.FileProvider = new PhysicalFileProvider("C:\\Users\\Semih\\source\\repos\\eCommerce\\"+ pluginFolderName + "\\wwwroot");
                var pluginName = pluginFolderName.Replace("Plugin.", "");
                option.RequestPath = "/"+ pluginName;
                staticOptions.Add(option);
            }

            app.UseStaticFiles();

            foreach (var option in staticOptions)
            {
                app.UseStaticFiles(option);
            }


        }




    }
}
