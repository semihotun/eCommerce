using Castle.DynamicProxy;
using Core.Utilities.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
namespace Core.Utilities.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private readonly string[] _pattern;
        private readonly ICacheService _cacheManager;
        public CacheRemoveAspect(params string[] pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            foreach (var item in _pattern)
            {
                _cacheManager.RemoveByPrefixAsync(item).GetAwaiter().GetResult();
            }
        }
    }
}
