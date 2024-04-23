using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Utilities.Caching
{
    public class RedisCacheManager : ICacheService
    {
        private static readonly ConcurrentDictionary<string, bool> CacheKeys = new();
        private readonly IDistributedCache _distributedCache;
        public RedisCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public string Get(string key)
        {
            return _distributedCache.GetString(key);
        }
        public void Set(string key, string value, int ttlSecond = 60)
        {
            _distributedCache.SetString(key, value, GetDistributedCacheEntryOptions(ttlSecond));
            CacheKeys.TryAdd(key, false);
        }
        public async Task<string> GetAsync(string key, CancellationToken cancellation = default)
        {
            return await _distributedCache.GetStringAsync(key, cancellation);
        }
        public async Task SetAsync(string key, string value, int ttlSecond = 60, CancellationToken cancellation = default)
        {
            await _distributedCache.SetStringAsync(key, value, GetDistributedCacheEntryOptions(ttlSecond), cancellation);
            CacheKeys.TryAdd(key, false);
        }
        public async Task RemovePatternAsync(string key, CancellationToken cancellation = default)
        {
            await _distributedCache.RemoveAsync(key, cancellation);
            CacheKeys.TryRemove(key, out bool _);
        }
        public async Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellation = default)
        {
            var tasks = CacheKeys.Keys
                .Where(x => x.StartsWith(prefixKey))
                .Select(y => RemovePatternAsync(y, cancellation));
            await Task.WhenAll(tasks);
        }
        private static DistributedCacheEntryOptions GetDistributedCacheEntryOptions(int ttlSecond = 60)
        {
            return new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(ttlSecond)
            };
        }
    }
}
