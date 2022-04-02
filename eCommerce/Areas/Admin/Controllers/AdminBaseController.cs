using Core.Utilities.DataTable;
using Core.Utilities.Results;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace eCommerce.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {

        [NonAction]
        protected IActionResult ToDataTableJson<T>(IDataResult<IPagedList<T>> data,DataTablesParam param)
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

        protected void Alert(string message, NotificationType notificationType)
        {
            var msg = "toastr." + notificationType.ToString().ToLower() + "('" + message + "','" + notificationType + "')" + "";
            TempData["notification"] = msg;

        }

        protected enum NotificationType
        {
            error,
            success,
            warning,
            info
        };

        protected void ResponseAlert(IResult result)
        {
            if(result.Success)
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : "İşlem Başarılı", NotificationType.success);
            }
            else
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : "İşlem Başarısız", NotificationType.error);
            }
        }

        protected void QueryAlert(IResult result)
        {
            if (!result.Success) { 
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : "Böyle bir Kullanıcı Yok", NotificationType.error);
            }
        }




    }
}
