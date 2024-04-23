using Business.Extension;
using Core.Extension;
using DataAccess.Extension;
using System.Collections.Generic;
using System.Reflection;

namespace eCommerceApi.Extensions
{
    public static class AssembliesExtension
    {
        public static Assembly[] GetAllAssemblies()
        {
            return new List<Assembly>
            {
                Assembly.GetExecutingAssembly(),
                BusinessAssembliesExtension.GetBusinessAssemblies(),
                CoreAssembliesExtension.GetCoreAssemblies(),
                DataAssembliesExtension.GetDataAssemblies(),
            }.ToArray();
        }
        public static Assembly GetClientAssemblies()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
