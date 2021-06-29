using Core.Library.Business.Abstract;
using Core.Library.Entities.Concrete;
using eCommerce.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{

    public class AdminLogin : AdminBaseController
    {
        private IAdminAuthService _adminAuthService;
        private IAdminService _adminService;
        public AdminLogin(IAdminAuthService adminAuthService, IAdminService adminService)
        {
            _adminAuthService = adminAuthService;
            _adminService = adminService;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<ActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _adminAuthService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return View();
            }
            var result = await _adminAuthService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                var basketCookie = Request.Cookies["UserToken"];
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(1));
                Response.Cookies.Append("UserToken", result.Data.Token, cookieOptions);
            }
            if (result.Success)
            {
                return Redirect("/Admin/AdminProduct/Index");
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
                Alert("Daha Önce Admin İlk kaydı yapıldı", NotificationType.error);
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserForRegisterDto adminUser)
        {
            if ((await _adminService.GetAdminCount()).Data > 0)
            {
                var registerUser = (await _adminAuthService.Register(adminUser)).Data;
                var result = await _adminAuthService.CreateAccessToken(registerUser);
                if (result.Success)
                {
                    var basketCookie = Request.Cookies["UserToken"];
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(1));
                    Response.Cookies.Append("UserToken", result.Data.Token, cookieOptions);
                    return Redirect("/Admin/AdminProduct/Index");
                }
            }
            else
            {
                Alert("Daha Önce Admin İlk kaydı yapıldı", NotificationType.error);
            }


            return View();
        }


    }


}
