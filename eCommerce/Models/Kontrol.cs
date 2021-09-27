using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Kontrol : ActionFilterAttribute
    {
        private readonly string[] _roles;
        public Kontrol(string roles)
        {
            _roles = roles.Split(",");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var AllRoles = _roles;
            var GirisYaptimi = filterContext.HttpContext.Request.Cookies["UserToken"];
            if (GirisYaptimi != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(GirisYaptimi);

                base.OnActionExecuting(filterContext);

            }
            else
            {
                filterContext.HttpContext.Response.Redirect("/AdminLogin/Login");
            }

        }

    }
}
