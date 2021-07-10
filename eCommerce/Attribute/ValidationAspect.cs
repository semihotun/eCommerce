using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Attribute;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eCommerce.Attribute
{
    public class ValidationaAspect : ActionFilterAttribute
    {


        private readonly Type _validatorType;
        private readonly string _ignore;
        public ValidationaAspect(Type validatorType, string IgnoreList = null)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new ArgumentException("Eror");
            }
            _validatorType = validatorType;
            _ignore = IgnoreList;
        }

        public void ValidationAddError(IValidator validator, IValidationContext context, FilterContext filterContext,
            string key = null)
        {
            ValidationResult result = validator.Validate(context);
            if (result.IsValid == false)
            {
                if (key != null)
                {
                    foreach (var error in result.Errors)
                    {
                        var validationKey = key + "." + error.PropertyName;
                        filterContext.ModelState.AddModelError(validationKey, error.ErrorMessage);
                    }
                }

                else
                {
                    foreach (var error in result.Errors)
                    {
                        filterContext.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
        }

        internal static IEnumerable<ValidationError> FindErrors(ModelStateDictionary modelState)
        {
            var result = new List<ValidationError>();
            var erroneousFields =
                modelState.Where(ms => ms.Value.Errors.Any()).Select(x => new { x.Key, x.Value.Errors });
            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors =
                    erroneousField.Errors.Select(error => new ValidationError(fieldKey, error.ErrorMessage));
                result.AddRange(fieldErrors);
            }

            return result;
        }
        public class AjaxResponse<T>
        {
            private string _typeName;
            public AjaxResponse(T value)
            {
                Value = value;
            }

            public string TypeName
            {
                get { return _typeName ?? typeof(T).Name; }
                set { _typeName = value; }
            }

            public T Value { get; set; }
        }

        public class ValidationError
        {
            public ValidationError(string key, string message)
            {
                Key = key;
                Message = message;
            }

            public string Key { get; set; }
            public string Message { get; set; }
        }
        public override async void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var ignore = new HashSet<string>();
            if (!string.IsNullOrWhiteSpace(_ignore))
            {
                var properties = _ignore.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
                ignore.UnionWith(properties);
            }
            var descriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var mainOrSub = filterContext.ActionArguments.Where(x => x.Value.GetType() == entityType);

            if (mainOrSub.Count() != 0)
            {
                var context = new ValidationContext<object>(mainOrSub.First().Value);
                ValidationAddError(validator, context, filterContext);
            }
            else
            {
                foreach (var parameterDescriptor in filterContext.ActionDescriptor.Parameters)
                {
                    var propertyInfos = parameterDescriptor.ParameterType.GetProperties().Where(x => x.PropertyType == entityType);
                    foreach (var propertyInfo in propertyInfos)
                    {
                        if (propertyInfo.PropertyType == entityType)
                        {
                            var paramValue = filterContext.ActionArguments.Where(x => x.Key == parameterDescriptor.Name).First().Value;
                            object subModelObject = propertyInfo.GetValue(paramValue);
                            var context = new ValidationContext<object>(subModelObject);
                            ValidationAddError(validator, context, filterContext, entityType.Name);

                        }
                    }
                }
            }
            if (filterContext.HttpContext.Request.Headers["Content-Type"] == "application/json; charset=UTF-8")
            {
                var errors = FindErrors(filterContext.ModelState).Where(e => !ignore.Contains(e.Key));

                if (errors.Any())
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    filterContext.Result =
                        new JsonResult(
                            new AjaxResponse<ValidationError[]>(errors.ToArray()) { TypeName = "ValidationErrors" },
                            new JsonSerializerSettings());
                }
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }

        }


    }


}
