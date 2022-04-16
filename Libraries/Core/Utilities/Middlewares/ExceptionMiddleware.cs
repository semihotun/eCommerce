using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using global::Serilog;
using Serilog.Core;
using System.IO;
using Newtonsoft.Json;

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
                await HandleExceptionAsync(httpContext, e);
            }
        }

        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string ErorDetail { get; set; }
        }
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            var errorDetails = new ErrorDetails();
            errorDetails.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (e.GetType() == typeof(ValidationException))
            {
                errorDetails.ErorDetail = e.Message;
                errorDetails.StatusCode = (int)HttpStatusCode.BadRequest;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
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


