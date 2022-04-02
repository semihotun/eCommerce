using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
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

        public object DictionaryNotification { get; set; }
    }
}
