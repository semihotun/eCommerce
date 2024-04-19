using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Areas.Admin.Controllers
{
    public class AdminController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
