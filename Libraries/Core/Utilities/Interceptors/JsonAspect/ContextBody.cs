using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors.JsonAspect
{
    public static class ContextBody
    {
        public static IDictionary<string,Object> ActionArguments { get; set; }

        public static ActionDescriptor ActionDescriptor { get; set; }
    }
}
