using Core.Utilities.IoC;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var _actionContextAccessor = ServiceTool.ServiceProvider.GetService(typeof(IActionContextAccessor)) as ActionContextAccessor;
            var contextAccessor = ServiceTool.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            var result = validator.Validate(new ValidationContext<object>(entity));
            if (!result.IsValid)
            {
                if (contextAccessor.HttpContext.Request.Path.StartsWithSegments("/api"))
                {
                    throw new ValidationException(result.Errors);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        _actionContextAccessor.ActionContext.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
        }
    }
}
