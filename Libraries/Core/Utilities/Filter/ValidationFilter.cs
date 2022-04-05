using Core.Utilities.Helper;
using Core.Utilities.Interceptors.JsonAspect;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Core.Utilities.Filter
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ContextBody.ActionArguments = filterContext.ActionArguments;
            ContextBody.ActionDescriptor = filterContext.ActionDescriptor;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var ignore = new HashSet<string>();
            if (filterContext.HttpContext.Request.Headers["Accept"] == "application/json, text/javascript, */*; q=0.01"
                && filterContext.HttpContext.Request.Method == HttpMethod.Post.Method)
            {
                var result = ((JsonResult)filterContext.Result).Value.GetType();
                if (!(result.Name == "DataTableNewVersionResult`1" || result.Name == "DataTableResult`1"))
                {
                    var errors = ModelStateHelper.FindErrors(filterContext.ModelState).Where(e => !ignore.Contains(e.Key));
                    if (errors.Any())
                    {

                        var factory = filterContext.HttpContext.RequestServices.GetService(typeof(ITempDataDictionaryFactory)) as ITempDataDictionaryFactory;
                        var alerts = factory.GetTempData(filterContext.HttpContext);
                        var notificationTempData=alerts["notification"];
                        filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        filterContext.Result =
                            new JsonResult(
                                new AjaxResponse<ValidationError[]>(errors.ToArray())
                                { TypeName = "ValidationErrors" ,
                                    DictionaryNotification= notificationTempData }
                                );
                        alerts.Clear();
                    }
                }

            }

        }


    }
}
