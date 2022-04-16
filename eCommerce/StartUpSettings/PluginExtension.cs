using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace eCommerce.StartUpSettings
{
    public static class PluginExtension
    {
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
            var result = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "Plugin.*.dll", SearchOption.AllDirectories)
                .Where(x => !x.Contains("Plugin.Base.dll"))
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);


            return result;

        }

        public static void AddPluginStaticFileProvier(this IApplicationBuilder app, IEnumerable<Assembly> pluginAssemblies)
        {
            var plugin = pluginAssemblies.Where(x => x.ManifestModule.Name.Contains("Views") == false);
            var staticOptions = new List<StaticFileOptions>();
            foreach (var item in plugin)
            {
                var pluginFolderName = item.ManifestModule.Name.Replace(".dll", "");
                var option = new StaticFileOptions();     
                try
                {
                    var solutionPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent;
                    option.FileProvider = new PhysicalFileProvider(solutionPath + "\\Plugins\\" + pluginFolderName + "\\wwwroot");
                }
                catch (System.Exception)
                {

                    var solutionPath = new DirectoryInfo(Directory.GetCurrentDirectory());
                    option.FileProvider = new PhysicalFileProvider(solutionPath + "\\Plugins\\" + pluginFolderName + "\\wwwroot");
                }
                var pluginName = pluginFolderName.Replace("Plugin.", "");
                option.RequestPath = "/" + pluginName;
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
