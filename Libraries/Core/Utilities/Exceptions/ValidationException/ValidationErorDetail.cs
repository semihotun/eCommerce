using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Utilities.Exceptions.ValidationException
{
#nullable enable
    public class ValidationErorDetail
    {
        public string? ErrorType { get; set; }
        public int? StatusCode { get; set; }
        public IEnumerable<ValidationData>? Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
