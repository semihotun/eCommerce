using System.Reflection;

namespace Business.Extension
{
    public static class BusinessAssembliesExtension
    {
        public static Assembly GetBusinessAssemblies()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
