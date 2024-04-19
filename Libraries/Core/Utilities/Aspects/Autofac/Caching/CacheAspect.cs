using Castle.DynamicProxy;
using Core.Utilities.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Core.Cache;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Core.Utilities.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheService _cacheManager;
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }
        public override void Intercept(IInvocation invocation)
        {
            //var methodName = string.Format($"{invocation.Method.ReflectedType.Name}.{invocation.Method.Name}");
            //var arguments = invocation.Arguments;
            //var key = $"{methodName}({BuildKey(arguments)})";
            //var cache = _cacheManager.Get(key);
            //if (cache != null)
            //{
            //    var data = JsonConvert.DeserializeObject(cache, new JsonSerializerSettings(){
            //        TypeNameHandling = TypeNameHandling.All
            //    });
            //    invocation.ReturnValue = typeof(Task)
            //        ?.GetMethod("FromResult")
            //        ?.MakeGenericMethod(data.GetType())
            //        .Invoke(null, new object[] { data });
            //    return;
            //}
            invocation.Proceed();
            //if (invocation.ReturnValue is Task taskResult)
            //{
            //    taskResult.GetAwaiter().GetResult();
            //    var result = typeof(Task<>)
            //        ?.MakeGenericType(taskResult.GetType().GetGenericArguments()[0])
            //        ?.GetProperty("Result")
            //        ?.GetValue(taskResult);
            //    _cacheManager.Set(key, JsonConvert.SerializeObject(result,new JsonSerializerSettings()
            //    {
            //        TypeNameHandling=TypeNameHandling.All
            //    }), _duration);
            //}
        }
        static string BuildKey(object[] args)
        {
            var sb = new StringBuilder();
            foreach (var arg in args)
            {
                var paramValues = arg.GetType().GetProperties().Select(p => p.GetValue(arg)?.ToString() ?? string.Empty);
                sb.AppendJoin('_', paramValues);
            }
            return sb.ToString();
        }
    }
}
