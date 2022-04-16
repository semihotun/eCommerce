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
        protected IActionResult ToDataTableJson<T>(IDataResult<IPagedList<T>> data, DataTablesParam param)
        {
            return Json(new DataTableResult<T>
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
            return Json(new DataTableNewVersionResult<T>
            {
                draw = param.Draw,
                recordsFiltered = data.Data.TotalItemCount,
                recordsTotal = data.Data.TotalItemCount,
                data = data.Data,
            }, new JsonSerializerSettings());
        }

        protected void Alert(string message, NotificationType notificationType,string title)
        {
            var msg = "swal(\"" + title + "\",\"" + message + "\",\"" + notificationType.ToString().ToLower() + "\")";

            TempData["notification"] = msg;

        }

        protected enum NotificationType
        {
            error,
            success,
        };

        protected void ResponseAlert(IResult result)
        {
            if (result.Success)
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : "İşlem Başarılı", NotificationType.success,"İşlem Başarılı");
            }
            else
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : "İşlem Başarısız", NotificationType.error,"İşlem Başarısız");
            }
        }
        protected void ResponseAlert(IdentityResult result)
        {
            if (result.Succeeded)
            {
                Alert("", NotificationType.success,"İşlem Başarılı");
            }
            else
            {
                var eror = string.Join(",", result.Errors.Select(x => x.Description));

                Alert(eror, NotificationType.error,"İşlem Başarısız");
            }
        }

        protected void ResponseDataAlert<T>(IDataResult<T> result, out IDataResult<T> outResult)
        {
            outResult = result;
            if (!result.Success)
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : "İşlem Başarısız", NotificationType.error, "İşlem Başarısız");
            }
        }





    }
}
