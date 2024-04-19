using Business.Constants;
using Business.Services.AuthAggregate.AdminAuths;
using Core.Utilities.Caching;
using Core.Utilities.Results;
using eCommerce.Areas.Admin.Controllers;
using Entities.RequestModel.AdminAggregate.AdminAuths;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
namespace eCommerce.Areas.AdminAuth.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Area("AdminAuth")]
    public class AdminLoginController : AdminBaseController
    {
        private readonly IAdminAuthService _adminAuthService;
        public AdminLoginController(IAdminAuthService adminAuthService, ICacheService cacheService)
        {
            _adminAuthService = adminAuthService;
        }
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(LoginReqModel userForLoginDto)
        {
            //_cacheService.Set("AdminToken-" + userToCheck.Id, result.Token, DateTime.Now.AddDays(1).Second);
            var result = await _adminAuthService.Login(userForLoginDto);
            if (result.Success)
            {
                HttpContext.Session.Set("AdminToken", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));
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
                    HttpContext.Session.Set("AdminToken", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));
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
        public IActionResult LogOut(Guid adminId)
        {
            HttpContext.Session.Remove("AdminToken");
            return RedirectToAction("Index", "Home");
        }
    }
}
