using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security;
namespace Core.Utilities.Identity
{
    public class AuthorizeControl : ActionFilterAttribute
    {
        private readonly string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public AuthorizeControl(string roles = null)
        {
            if(roles != null)
            {
                _roles = roles.Split(",");
            }
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var roleClaims = _httpContextAccessor?.HttpContext?.User?.Claims;
            var isLogin = filterContext.HttpContext.Request.Cookies["UserToken"];
            if (isLogin != null || roleClaims?.Count() > 0)
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                throw new SecurityException("AuthorizationsDenied");
            }
        }
    }
}
