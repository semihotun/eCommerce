using System.Reflection;

namespace Core.Extension
{
    public static class CoreAssembliesExtension
    {
        public static Assembly GetCoreAssemblies()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
