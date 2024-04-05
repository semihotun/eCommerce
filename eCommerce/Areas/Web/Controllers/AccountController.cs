using Entities.ViewModels.WebViewModel.Account;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Areas.Web.Controllers
{
    public class AccountController : WebBaseController
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVm model)
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVm model)
        {
            return View();
        }
    }
}
