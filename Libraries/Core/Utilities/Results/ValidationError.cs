using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
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

}
