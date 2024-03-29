﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text;
namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            if (invocation.Arguments.Length > 0)
            {
                var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
                var arguments = invocation.Arguments;
                var key = $"{methodName}({BuildKey(arguments)})";
                if (_cacheManager.IsAdd(key))
                {
                    invocation.ReturnValue = _cacheManager.Get(key);
                    return;
                }
                invocation.Proceed();
                _cacheManager.Add(key, invocation.ReturnValue, _duration);
            }
            else
            {
                var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
                if (_cacheManager.IsAdd(methodName))
                {
                    invocation.ReturnValue = _cacheManager.Get(methodName);
                    return;
                }
                invocation.Proceed();
                _cacheManager.Add(methodName, invocation.ReturnValue, _duration);
            }
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
