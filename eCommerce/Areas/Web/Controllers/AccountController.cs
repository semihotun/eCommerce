using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Areas.Web.Controllers
{
    public class AccountController : WebBaseController
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
