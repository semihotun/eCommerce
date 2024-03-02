using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Data.SqlClient;
namespace Core.Utilities.Migration
{
    public static class HostExtension
    {
        public static IHost MigrateDbContext<TContext>(this IHost host, Action<TContext, IServiceProvider,bool> seeder)
             where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var sp = scope.ServiceProvider;
                var logger = sp.GetRequiredService<ILogger<TContext>>();
                var context = sp.GetService<TContext>();
                try
                {
                    var retry = Policy.Handle<SqlException>()
                        .WaitAndRetry(new TimeSpan[]
                        {
                            TimeSpan.FromSeconds(3),
                            TimeSpan.FromSeconds(5),
                            TimeSpan.FromSeconds(8),
                        });
                    retry.Execute(() => InvokeSeeder(seeder, context, sp,logger));
                }
                catch (Exception)
                {
                    logger.LogError("Migration Başaramadı");
                }
            }
            return host;
        }
        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider,bool> seeder,
            TContext context,
            IServiceProvider services,
            ILogger<TContext> logger
            )
            where TContext : DbContext
        {
            var created=context.Database.EnsureCreated();
            context.Database.Migrate();
            logger.LogInformation("Migration Çalıştı");
            seeder(context, services, created);
        }
    }
}
