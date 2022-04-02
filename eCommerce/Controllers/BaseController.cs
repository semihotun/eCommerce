using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class BaseController : Controller
    {
        #region Fields

        #endregion

        #region Constructors

        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
