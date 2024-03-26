using Core.Utilities.DataTable;
using Core.Utilities.Results;
using Entities.Others;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using X.PagedList;
namespace eCommerce.Controllers
{
    public class BaseController : Controller
    {
        [NonAction]
        protected IActionResult ToDataTableJson<T>(Result<IPagedList<T>> data, DataTablesParam param)
        {
            return Json(new DataTableResult<T>
            {
                AaData = data.Data,
                SEcho = param.sEcho,
                ITotalDisplayRecords = data.Data.TotalItemCount,
                ITotalRecords = data.Data.TotalItemCount
            }, new JsonSerializerSettings());
        }
        [NonAction]
        protected IActionResult ToDataTableJson<T>(Result<IPagedList<T>> data, DTParameters param)
        {
            return Json(new DataTableNewVersionResult<T>
            {
                Draw = param.Draw,
                RecordsFiltered = data.Data.TotalItemCount,
                RecordsTotal = data.Data.TotalItemCount,
                Data = data.Data,
            }, new JsonSerializerSettings());
        }
        protected void Alert(string message, NotificationType notificationType, string title)
        {
            var msg = "swal(\"" + title + "\",\"" + message + "\",\"" + notificationType.ToString().ToLower() + "\")";
            TempData["notification"] = msg;
        }
        protected enum NotificationType
        {
            error,
            success,
        };
        protected void ResponseAlert(Result result)
        {
            if (result.Success)
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : "İşlem Başarılı", NotificationType.success, "İşlem Başarılı");
            }
            else
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : "İşlem Başarısız", NotificationType.error, "İşlem Başarısız");
            }
        }
        protected void ResponseAlert(IdentityResult result)
        {
            if (result.Succeeded)
            {
                Alert("", NotificationType.success, "İşlem Başarılı");
            }
            else
            {
                var eror = string.Join(",", result.Errors.Select(x => x.Description));
                Alert(eror, NotificationType.error, "İşlem Başarısız");
            }
        }
        protected void ResponseDataAlert<T>(Result<T> result, out Result<T> outResult)
        {
            outResult = result;
            if (!result.Success)
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : "İşlem Başarısız", NotificationType.error, "İşlem Başarısız");
            }
        }
    }
}
