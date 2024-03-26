using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        readonly IMemoryCache _memoryCache;
        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }
        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollection = typeof(MemoryCache)
                .GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new();
            foreach (var cacheItem in cacheEntriesCollection)
            {
                cacheCollectionValues.Add(cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null));
            }
            foreach (var key in cacheCollectionValues.Where(d =>
            new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase)
                .IsMatch(d.Key.ToString()))
                .Select(d => d.Key).ToList())
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
