using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Others;
using Newtonsoft.Json;
using X.PagedList;
using Core.Utilities.DataTable;

namespace eCommerce.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        [NonAction]
        protected IActionResult ToDataTableJson<T>(IDataResult<IPagedList<T>> data,DataTablesParam param)
        {
            return Json(new
            {
                aaData = data.Data,
                sEcho = param.sEcho,
                iTotalDisplayRecords = data.Data.TotalItemCount,
                iTotalRecords = data.Data.TotalItemCount
            }, new JsonSerializerSettings());
        }
        [NonAction]
        protected IActionResult ToDataTableJson<T>(IDataResult<IPagedList<T>> data, DTParameters param)
        {
            return Json(new
            {
                draw = param.Draw,
                recordsFiltered = data.Data.TotalItemCount,
                recordsTotal = data.Data.TotalItemCount,
                data = data.Data,
            }, new JsonSerializerSettings());
        }

        protected void Alert(string Message, NotificationType NotificationType)
        {
            var Msg = "toastr." + NotificationType.ToString().ToLower() + "('" + Message + "','" + NotificationType + "')" + "";
            TempData["notification"] = Msg;
        }
        protected enum NotificationType
        {
            error,
            success,
            warning,
            info
        };

    }
}
