using System.Reflection;

namespace DataAccess.Extension
{
    public static class DataAssembliesExtension
    {
        public static Assembly GetDataAssemblies()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
