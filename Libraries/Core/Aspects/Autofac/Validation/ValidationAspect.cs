using Castle.DynamicProxy;
using Core.Const;
using Core.Utilities.Exceptions.ValidationException;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new ArgumentException(CoreMessages.ThisIsNotValidationClass);
            }
            _validatorType = validatorType;
        }
        public override void Intercept(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            foreach (var entity in invocation.Arguments.Where(t => t.GetType() == _validatorType.BaseType.GetGenericArguments()[0]))
            {
                var _actionContextAccessor = ServiceTool.ServiceProvider.GetService(typeof(IActionContextAccessor)) as ActionContextAccessor;
                var contextAccessor = ServiceTool.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
                var result = validator.Validate(new ValidationContext<object>(entity));
                if (!result.IsValid)
                {
                    if (contextAccessor.HttpContext.Request.Path.StartsWithSegments("/api"))
                    {
                        throw new CustomValidatonException(result.Errors.Select(x => new ValidationData(x.PropertyName, x.ErrorMessage)));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            _actionContextAccessor.ActionContext.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                        }
                        invocation.ReturnValue = Task.FromResult(Result.ErrorResult("Validation error"));
                        return;
                    }
                }
            }
            invocation.Proceed();
        }
    }
}
