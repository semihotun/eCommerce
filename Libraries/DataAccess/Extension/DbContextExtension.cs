using DataAccess.Context;
using DataAccess.ContextSeed.eCommerceDbSeed;
using DataAccess.Cqrs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DataAccess.Extension
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("WriteConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                        sqlOptions.MigrationsHistoryTable("__MyMigrationsHistory", "mySchema");
                    });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            },ServiceLifetime.Scoped);
            services.AddDbContext<ECommerceReadContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("ReadConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                        sqlOptions.MigrationsHistoryTable("__MyMigrationsHistory", "mySchema");
                    });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            },ServiceLifetime.Transient);
            //var optionBuilderReadCtx = new DbContextOptionsBuilder<ECommerceReadContext>()
            //.UseSqlServer(configuration.GetConnectionString("ReadConnection"));
            //using (var readCtx = new ECommerceReadContext(optionBuilderReadCtx.Options))
            //{
            //    if (readCtx.Database.EnsureCreated())
            //    {
            //        readCtx.Database.Migrate();
            //    }
            //    else
            //    {
            //        readCtx.Database.EnsureCreated();
            //        readCtx.Database.Migrate();
            //    }
            //}
            var optionBuilder = new DbContextOptionsBuilder<ECommerceContext>()
            .UseSqlServer(configuration.GetConnectionString("WriteConnection"));
            using (var ctx = new ECommerceContext(optionBuilder.Options))
            {
                if (ctx.Database.EnsureCreated())
                {
                    ctx.Database.ExecuteSqlRaw("EXEC sp_configure 'show advanced options', 1; RECONFIGURE; EXEC sp_configure 'max text repl size', -1; RECONFIGURE;");
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

            return services;
        }
    }
}
