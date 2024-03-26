using Core.Utilities.Results;
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
            foreach (var erroneousField in modelState.Where(ms => ms.Value.Errors.Any()).Select(x => new { x.Key, x.Value.Errors }))
            {
                result.AddRange(erroneousField.Errors.Select(error => new ValidationError(erroneousField.Key, error.ErrorMessage)));
            }
            return result;
        }
    }
}
