using Business.Constants;
using Core.Library.Business.AdminAggregate.AdminAuths;
using Core.Library.Business.AdminAggregate.AdminServices;
using eCommerce.Areas.Admin.Controllers;
using Entities.Concrete.AdminUserAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Controllers
{
    public class AdminLogin : AdminBaseController
    {
        private readonly IAdminAuthService _adminAuthService;
        private readonly IAdminService _adminService;
        public AdminLogin(IAdminAuthService adminAuthService, IAdminService adminService)
        {
            _adminAuthService = adminAuthService;
            _adminService = adminService;
        }
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _adminAuthService.Login(userForLoginDto);
            if (result.Success)
            {
                CookieOptions cookieOptions = new()
                {
                    Expires = new DateTimeOffset(DateTime.Now.AddDays(1))
                };
                Response.Cookies.Append("UserToken", result.Data.Token, cookieOptions);
                return Redirect("/Admin/AdminProduct/ProductList");
            }
            return View();
        }
        public async Task<IActionResult> Register()
        {
            if ((await _adminService.GetAdminCount()).Data == 0)
            {
                return View();
            }
            else
            {
                Alert(Messages.OperationFailed, NotificationType.error);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterDto adminUser)
        {
            if ((await _adminService.GetAdminCount()).Data == 0)
            {
                var result = await _adminAuthService.Register(adminUser);
                if (result.Success && result.Data != null)
                {
                    CookieOptions cookieOptions = new ()
                    {
                        Expires = new DateTimeOffset(DateTime.Now.AddDays(1))
                    };
                    Response.Cookies.Append("UserToken", result.Data.Token, cookieOptions);
                    Alert(Messages.OperationSuccessful, NotificationType.success);
                    return Redirect("/Admin/AdminProduct/ProductList");
                }
            }
            else
            {
                Alert(Messages.OperationFailed, NotificationType.error);
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            Response.Cookies.Delete("UserToken");
            return RedirectToAction("Index", "Home");
        }
    }
}
