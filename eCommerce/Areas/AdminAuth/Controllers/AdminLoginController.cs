using Business.Services.AuthAggregate.AdminAuths;
using Entities.RequestModel.AdminAggregate.AdminAuths;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
namespace eCommerce.Areas.AdminAuth.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Area("AdminAuth")]
    public class AdminLoginController : Controller
    {
        private readonly IAdminAuthService _adminAuthService;
        public AdminLoginController(IAdminAuthService adminAuthService)
        {
            _adminAuthService = adminAuthService;
        }
        public IActionResult LoginPage() => View();
        public async Task<IActionResult> RegisterPage() => View();
        public async Task<IActionResult> Login([FromBody] LoginReqModel userForLoginDto)
        {
            var result = await _adminAuthService.Login(userForLoginDto);
            if (result.Success)
            {
                HttpContext.Session.Set("Token", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result.Data)));
            }
            return Json(result);
        }
        public async Task<IActionResult> Register([FromBody] RegisterReqModel adminUser)
        {
            var result = await _adminAuthService.Register(adminUser);
            if (result.Success)
            {
                HttpContext.Session.Set("Token", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result.Data)));
            }
            return Json(result);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Token");
            return Json(true);
        }
    }
}
