using System;

namespace Core.Utilities.Generate
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class IgnoreGeneratorAttribute : Attribute
    {
        public IgnoreGeneratorAttribute()
        {
        }
    }
}
