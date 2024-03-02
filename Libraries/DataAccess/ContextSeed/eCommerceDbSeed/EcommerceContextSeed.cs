using DataAccess.Context;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace DataAccess.ContextSeed.eCommerceContextSeed
{
    public class EcommerceContextSeed
    {
        public async Task SeedAsync(eCommerceContext context, ILogger<eCommerceContext> logger)
        {
            var policy = CreatePolicy(
                logger, nameof(eCommerceContext));
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
        private AsyncRetryPolicy CreatePolicy(ILogger<eCommerceContext> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(retry),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception.Message);
                    }
               );
        }
    }
}
