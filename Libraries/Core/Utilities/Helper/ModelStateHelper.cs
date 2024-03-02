﻿using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
namespace Core.Utilities.Helper
{
    public static class ModelStateHelper
    {
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
    }
}
