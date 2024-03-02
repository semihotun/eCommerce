using Autofac.Extensions.DependencyInjection;
using Core.Utilities.Generate;
using Core.Utilities.Migration;
using DataAccess.Context;
using DataAccess.ContextSeed.eCommerceContextSeed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace eCommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDbContext<eCommerceContext>((context, services,created) =>
            {            
                if(created)
                {
                    var logger = (ILogger<eCommerceContext>)services.GetService(typeof(ILogger<eCommerceContext>));
                    var dbContextSeeder = new EcommerceContextSeed();
                    dbContextSeeder.SeedAsync(context, logger).Wait();
                }
            });
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options => options.AddServerHeader = true);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
