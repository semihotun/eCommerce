using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Interceptors.JsonAspect;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }
            _validatorType = validatorType;
        }
        public override async void Intercept(IInvocation invocation)
        {
            var _actionContextAccessor = ServiceTool.ServiceProvider.GetService(typeof(IActionContextAccessor)) as ActionContextAccessor;
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            var parameterValueList = _actionContextAccessor.ActionContext.HttpContext.Request.Query.Keys.ToList();
            foreach (var entity in entities)
            {
                var context = new ValidationContext<object>(entity);
                var result = validator.Validate(context);
                if (result.IsValid == false)
                {
                    foreach (var error in result.Errors)
                    {
                        foreach (var parameterDescriptor in ContextBody.ActionDescriptor.Parameters)
                        {
                            var propertyInfos = parameterDescriptor.ParameterType.GetProperties().Where(x => x.PropertyType == entityType);
                            if (propertyInfos.Any())
                            {
                                var vmModelName = entity.GetType().Name + "." + error.PropertyName;
                                _actionContextAccessor.ActionContext.ModelState.AddModelError(vmModelName, error.ErrorMessage);
                            }
                            else
                            {
                                _actionContextAccessor.ActionContext.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                            }
                        }
                    }
                    base.SetIsSuccess(false);
                }
            }
            if (base.IsSuccess == true)
            {
                invocation.Proceed();
            }
            else
            {
                invocation.ReturnValue = ErorResultAsync();
            }
        }
        private static async Task<IResult> ErorResultAsync()
        {
            var result = new ErrorResult();
            return result;
        }
    }
}
