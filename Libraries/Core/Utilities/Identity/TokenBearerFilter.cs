using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Identity
{
    public class TokenBearerFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var byteArray = default(byte[]);
            var isAuth = (bool)context.HttpContext?.Session.TryGetValue("Token", out byteArray);
            if (isAuth && !context.HttpContext.User.Claims.Any())
            {
                var data = JsonConvert.DeserializeObject<AccessToken>(Encoding.UTF8.GetString(byteArray));
                var claims = data.Claims.Select(x => new Claim(x.ClaimType, x.Value)).ToList();
                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                context.HttpContext.User = new ClaimsPrincipal(claimsIdentity);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
