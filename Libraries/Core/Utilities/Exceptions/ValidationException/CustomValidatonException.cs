using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Core.Utilities.Exceptions.ValidationException
{
    public class CustomValidatonException : Exception
    {
        private readonly IEnumerable<ValidationData> _message;
        public override string Message { get; }
        public CustomValidatonException(IEnumerable<ValidationData> message)
        {
            _message = message;
            Message = JsonConvert.SerializeObject(_message);
        }
    }
}
