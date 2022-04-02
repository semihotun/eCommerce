using Core.Library;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.StartUpSettings
{
    public static class DbContextExtension
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<eCommerceContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                     x => x.MigrationsHistoryTable("__MyMigrationsHistory", "mySchema"));
                options.EnableSensitiveDataLogging();
            }, ServiceLifetime.Transient);

            services.AddDbContext<CoreContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                     x => x.MigrationsHistoryTable("__MyMigrationsHistory", "mySchema"));
                options.EnableSensitiveDataLogging();
            }, ServiceLifetime.Transient);

            var eCommerceContextOptionsBuilder = new DbContextOptionsBuilder<eCommerceContext>()
             .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            using var ecommerceContext = new eCommerceContext(eCommerceContextOptionsBuilder.Options);
        }

    }
}
