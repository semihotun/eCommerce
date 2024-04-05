using Business.Constants;
using Business.Services.AdminAggregate.AdminAuths;
using eCommerce.Areas.Admin.Controllers;
using Entities.RequestModel.AdminAggregate.AdminAuths;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.AdminAuth.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Area("AdminAuth")]
    public class AdminLoginController : AdminBaseController
    {
        private readonly IAdminAuthService _adminAuthService;
        public AdminLoginController(IAdminAuthService adminAuthService)
        {
            _adminAuthService = adminAuthService;
        }
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginReqModel userForLoginDto)
        {
            var result = await _adminAuthService.Login(userForLoginDto);
            if (result.Success)
            {
                CookieOptions cookieOptions = new()
                {
                    Expires = new DateTimeOffset(DateTime.Now.AddDays(1))
                };
                Response.Cookies.Append("UserToken", result.Data!.Token, cookieOptions);
                return Redirect("/Admin/AdminProduct/ProductList");
            }
            return View();
        }
        public async Task<IActionResult> Register()
        {
            if ((await _adminAuthService.GetAdminCount()).Data == 0)
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
        public async Task<IActionResult> Register(RegisterReqModel adminUser)
        {
            if ((await _adminAuthService.GetAdminCount()).Data == 0)
            {
                var result = await _adminAuthService.Register(adminUser);
                if (result.Success && result.Data != null)
                {
                    CookieOptions cookieOptions = new()
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
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("UserToken");
            return RedirectToAction("Index", "Home");
        }
    }
}
