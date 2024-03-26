using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            if (method.Name != "Validate")
            {
                var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
                classAttributes.AddRange(methodAttributes);
                return classAttributes.OrderBy(x => x.Priority).ToArray();
            }
            else
            {
                return classAttributes.ToArray();
            }
        }
    }
}
