using Core.Utilities.Exceptions;
using Core.Utilities.Exceptions.ValidationException;
using global::Serilog;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;
using System.Threading.Tasks;
namespace Core.Utilities.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleApiExceptionAsync(httpContext, e);
            }
        }
        private static async Task HandleApiExceptionAsync(HttpContext httpContext, Exception e)
        {
            var errorDetails = new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            if (e.GetType().Name == nameof(CustomValidatonException))
            {
                var validationErorDetail = new ValidationErorDetail
                {
                    Message = JsonConvert.DeserializeObject<IEnumerable<ValidationData>>(e.Message),
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    ErrorType = "ValidationException"
                };
                var customValidationObject = JsonConvert.SerializeObject(validationErorDetail);
                Log.Error(customValidationObject);
                await httpContext.Response.WriteAsync(customValidationObject);
                return;
            }
            else if (e.GetType() == typeof(ApplicationException))
            {
                errorDetails.ErorDetail = e.Message;
                errorDetails.StatusCode = (int)HttpStatusCode.BadRequest;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (e.GetType() == typeof(UnauthorizedAccessException))
            {
                errorDetails.ErorDetail = e.Message;
                errorDetails.StatusCode = StatusCodes.Status401Unauthorized;
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else if (e.GetType() == typeof(SecurityException))
            {
                errorDetails.ErorDetail = e.Message;
                errorDetails.StatusCode = StatusCodes.Status401Unauthorized;
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else
            {
                errorDetails.ErorDetail = "Something went wrong. Please try again.";
            }
            var serializeObject = JsonConvert.SerializeObject(errorDetails);
            Log.Error(serializeObject);
            await httpContext.Response.WriteAsync(serializeObject);
        }
    }
}
