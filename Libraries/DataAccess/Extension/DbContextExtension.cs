using DataAccess.Context;
using DataAccess.ContextSeed.eCommerceDbSeed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
namespace DataAccess.Extension
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                        sqlOptions.MigrationsHistoryTable("__MyMigrationsHistory", "mySchema");
                    });
            });
            var optionBuilder = new DbContextOptionsBuilder<ECommerceContext>()
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            using (var ctx = new ECommerceContext(optionBuilder.Options))
            {
                if (ctx.Database.EnsureCreated())
                {
                    ctx.Database.Migrate();
                    EcommerceContextSeed.SeedAsync(ctx).GetAwaiter().GetResult();
                }
                else
                {
                    ctx.Database.EnsureCreated();
                    ctx.Database.Migrate();
                }
            }
            return services;
        }
    }
}
