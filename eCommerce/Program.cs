using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                //.ConfigureContainer<ContainerBuilder>(builder =>
                //{
                //    builder.RegisterModule(new AutofacBusinessModule());
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //Removing Server Header
                    webBuilder.ConfigureKestrel(options => options.AddServerHeader = false);

                    webBuilder.UseStartup<Startup>();
                });
    }
}
