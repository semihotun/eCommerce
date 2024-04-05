using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Core.CrossCuttingConcerns.Caching
{
    public static class RedisExtension
    {
        public static IServiceCollection AddRedis(this IServiceCollection services,IConfiguration configuration)
        {
            var conf = configuration.GetSection("Redis").Get<RedisSetting>();
            if (conf != null)
            {
                services.AddTransient<ICacheService, RedisCacheManager>();
                services.AddStackExchangeRedisCache(option =>
                {
                    option.ConfigurationOptions = new ConfigurationOptions
                    {
                        EndPoints = { { conf.Host, conf.Port } },
                        Password = conf.Password,
                        Ssl = conf.Ssl,
                        SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                    };
                });
            }
            return services;
        }
    }
}
