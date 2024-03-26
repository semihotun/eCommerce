using Autofac.Extensions.DependencyInjection;
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
            host.MigrateDbContext<ECommerceContext>((context, services, created) =>
            {
                if (created)
                {
                    var logger = (ILogger<ECommerceContext>)services.GetService(typeof(ILogger<ECommerceContext>));
                    var dbContextSeeder = new EcommerceContextSeed();
                    EcommerceContextSeed.SeedAsync(context, logger).Wait();
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
