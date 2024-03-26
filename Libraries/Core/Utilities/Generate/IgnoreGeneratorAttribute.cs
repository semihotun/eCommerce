using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Generate
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public  class IgnoreGeneratorAttribute : Attribute
    {
        public IgnoreGeneratorAttribute()
        {
        }
    }
}
