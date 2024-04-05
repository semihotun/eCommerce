using System.Reflection;

namespace Plugin.Iyzico.Extension
{
    public static class IyzicoAssembliesExtension
    {
        public static Assembly GetIyzicoAssemblies()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
