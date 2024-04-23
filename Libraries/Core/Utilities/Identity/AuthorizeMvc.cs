using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.Identity
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorizeMvc : ActionFilterAttribute
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizeMvc(params string[] roles)
        {
            _roles = roles;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_httpContextAccessor.HttpContext?.User.Identity.IsAuthenticated == false)
            {
                filterContext.HttpContext.Response.Redirect("/Error/Error/Index");
                base.OnActionExecuting(filterContext);
            }
            var roleClaims = _httpContextAccessor.HttpContext?.User.Claims
                .Where(x => x.Type == ClaimTypes.Role)
                 .Select(c => c.Value);
            if (!_roles.All(role => roleClaims.Contains(role)))
            {
                filterContext.HttpContext.Response.Redirect("/Error/Error/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}