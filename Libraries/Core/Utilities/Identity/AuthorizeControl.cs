using Core.Utilities.Caching;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Http;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
namespace Core.Utilities.Identity
{
    public class AuthorizeControl : ActionFilterAttribute
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICacheService _cacheService;
        public AuthorizeControl(string roles ="")
        {
            if (roles != null)
            {
                _roles = roles.Split(",");
            }
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ss = filterContext.HttpContext.Session.TryGetValue("UserId");
            var roleClaims = _httpContextAccessor?.HttpContext?.User?.Claims;
            var isLogin = filterContext.HttpContext.Request.Cookies["Token"];

            //filterContext.
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            //if ()
            //{
            //    base.OnActionExecuting(filterContext);
            //}
            //else
            //{
            //    throw new SecurityException("AuthorizationsDenied");
            //}

            //var ss = filterContext.HttpContext.Request.Headers;
            var login = filterContext.HttpContext.User.Identity.IsAuthenticated;
            var apiLogin = _httpContextAccessor?.HttpContext?.User.Identity.IsAuthenticated;
            //var isLogin = _httpContextAccessor.;
            //if (apiLogin == true)
            //{
            //    base.OnActionExecuting(filterContext);
            //}
            //else
            //{
            //    throw new SecurityException("AuthorizationsDenied");
            //}
            base.OnActionExecuting(filterContext);
        }
    }
}
