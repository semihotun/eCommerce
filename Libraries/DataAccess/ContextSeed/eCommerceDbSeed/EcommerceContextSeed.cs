using DataAccess.Context;
using Polly;
using Polly.Retry;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace DataAccess.ContextSeed.eCommerceDbSeed
{
    public static class EcommerceContextSeed
    {
        public static async Task SeedAsync(ECommerceContext context)
        {
            var policy = CreatePolicy(3);
            await policy.ExecuteAsync(async () =>
            {
                using (context)
                {
                    var assm = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces().Any(x => x.Name == "ISeed`1"));
                    foreach (var item in assm)
                    {
                        var method = item.GetMethod("GetSeedData");
                        var obj = Activator.CreateInstance(item);
                        var returnType = method.ReturnType;
                        var dataObjects = (IEnumerable<object>)method.Invoke(obj, null);
                        context.AddRange(dataObjects);
                    }
                    await context.SaveChangesAsync();
                }
            });
        }
        private static AsyncRetryPolicy CreatePolicy(int retries)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(retry),
                    onRetry: (exception, _, _, _) => Log.Warning(exception.Message)
               );
        }
    }
}
