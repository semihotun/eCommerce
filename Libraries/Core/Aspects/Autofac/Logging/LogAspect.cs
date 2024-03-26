using Castle.DynamicProxy;
using Core.Const;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new ArgumentException(CoreMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerService);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase?.Info(GetLogDetail(invocation));
        }
        private string GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (var i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }
            if (_httpContextAccessor.HttpContext.User.Identity != null)
            {
                var logDetail = new LogDetail()
                {
                    MethodName = invocation.Method.Name,
                    Parameters = logParameters,
                    User = (_httpContextAccessor.HttpContext == null || _httpContextAccessor.HttpContext.User.Identity.Name == null) ? "?" : _httpContextAccessor.HttpContext.User.Identity.Name
                };
                return JsonConvert.SerializeObject(logDetail);
            }
            else
            {
                var logDetail = new LogDetail()
                {
                    MethodName = invocation.Method.Name,
                    Parameters = logParameters,
                    User = new JwtSecurityTokenHandler().ReadJwtToken(
                        _httpContextAccessor.HttpContext.Request.Cookies["UserToken"])
                        ?.Claims.FirstOrDefault(x => x.Type == "email")?.Value
                };
                return JsonConvert.SerializeObject(logDetail);
            }
        }
    }
}
