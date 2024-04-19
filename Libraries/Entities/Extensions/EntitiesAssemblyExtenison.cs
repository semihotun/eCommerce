using System.Reflection;

namespace Entities.Extensions
{
    public static class EntitiesAssemblyExtenison
    {
        public static Assembly GetAssemlyExtension() { return Assembly.GetExecutingAssembly(); }
    }
}
