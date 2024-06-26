using DataAccess.Context;
using DataAccess.ContextSeed.eCommerceDbSeed;
using DataAccess.EventSourcing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DataAccess.Extension
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceContext>((_, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("WriteConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                        sqlOptions.MigrationsHistoryTable("__MyMigrationsHistory", "mySchema");
                    });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Scoped);
            services.AddDbContext<ECommerceReadContext>((_, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("ReadConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                        sqlOptions.MigrationsHistoryTable("__MyMigrationsHistory", "mySchema");
                    });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient);
            return services;
        }
        public static void MigrateDbContext(IConfiguration configuration)
        {
            var optionBuilder = new DbContextOptionsBuilder<ECommerceContext>()
                .UseSqlServer(configuration.GetConnectionString("WriteConnection"));
            using var ctx = new ECommerceContext(optionBuilder.Options);
            if (ctx.Database.EnsureCreated())
            {
                MssqlDbContextAddAllCdcTable.AddAllCdc(ctx);
                ctx.AddConnector().GetAwaiter().GetResult();
                EcommerceContextSeed.SeedAsync(ctx).GetAwaiter().GetResult();
            }
            else
            {
                ctx.Database.EnsureCreated();
                ctx.Database.Migrate();
            }
        }
    }
}
