using Business.Constants;
using Core.Utilities.DataTable;
using Core.Utilities.Identity;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [AuthorizeControl("")]
    [Area("Admin")]
    public class AdminBaseController : Controller
    {
        [NonAction]
        protected IActionResult ToDataTableJson<T>(Result<IPagedList<T>> data, DataTablesParam param)
        {
            return Json(new DataTableResult<T>
            {
                AaData = data.Data!.Data,
                SEcho = param.sEcho,
                ITotalDisplayRecords = data.Data!.TotalCount,
                ITotalRecords = data.Data.TotalCount
            }, new JsonSerializerSettings());
        }
        [NonAction]
        protected IActionResult ToDataTableJson<T>(Result<IPagedList<T>> data, DTParameters param)
        {
            return Json(new DataTableNewVersionResult<T>
            {
                Draw = param.Draw,
                RecordsFiltered = data.Data!.TotalCount,
                RecordsTotal = data.Data.TotalCount,
                Data = data.Data.Data,
            }, new JsonSerializerSettings());
        }
        protected void Alert(string message, NotificationType notificationType)
        {
            TempData["notification"] = "toastr." + notificationType.ToString().ToLower() + "('" + message + "','" + notificationType + "')";
        }
        protected enum NotificationType
        {
            error,
            success,
            warning,
            info
        };
        protected void ResponseAlert(Result? result)
        {
            if (result!.Success)
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : Messages.OperationSuccessful, NotificationType.success);
            }
            else
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : Messages.OperationFailed, NotificationType.error);
            }
        }
        protected Result<T>? ResponseAlert<T>(Result<T>? result)
        {
            if (result!.Success)
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : Messages.OperationSuccessful, NotificationType.success);
            }
            else
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : Messages.OperationFailed, NotificationType.error);
            }
            return result;
        }
        protected void QueryAlert(Result result)
        {
            if (!result.Success)
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : Messages.OperationFailed, NotificationType.error);
            }
        }
        protected void ResponseDataAlert<T>(Result<T> result, out Result<T> outResult)
        {
            outResult = result;
            if (!result.Success)
            {
                Alert(!string.IsNullOrEmpty(result.Message) ? result.Message : Messages.OperationFailed, NotificationType.error);
            }
        }
    }
}
