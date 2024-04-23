using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security;
using System.Security.Claims;

namespace Core.Utilities.Aspects.Autofac.Secure
{
    public class AuthAspect : MethodInterception
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthAspect(params string[]? roles)
        {
            _roles = roles;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            if (_httpContextAccessor.HttpContext?.User.Identity.IsAuthenticated == true)
            {
                var roleClaims = _httpContextAccessor.HttpContext?.User.Claims
                    .Where(x => x.Type == ClaimTypes.Role)
                     .Select(c => c.Value);
                if (!_roles.All(role => roleClaims.Contains(role)))
                {
                    throw new SecurityException("AuthorizationDenied");
                }
                return;
            }
            throw new SecurityException("AuthorizationsDenied");
        }
    }
}
