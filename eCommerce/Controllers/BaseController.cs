using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
