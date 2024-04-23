using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Areas.Errors.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Area("Error")]
    public class ErrorController : Controller
    {
        public IActionResult Index(ErrorViewModel model)
        {
            return View(model);
        }
    }
}
