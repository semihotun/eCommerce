using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheService
    {
        string? Get(string key);
        void Set(string key, string value, int ttlSecond = 60);
        Task<string?> GetAsync(string key, CancellationToken cancellation = default);
        Task SetAsync(string key, string value, int ttlSecond = 60, CancellationToken cancellation = default);
        Task RemovePatternAsync(string key, CancellationToken cancellation = default);
        Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellation = default);
    }
}
