using Business.Extension;
using Core.Extension;
using DataAccess.Extension;
using Plugin.Iyzico.Extension;
using System.Collections.Generic;
using System.Reflection;

namespace eCommerce.Extensions
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
                IyzicoAssembliesExtension.GetIyzicoAssemblies()
            }.ToArray();
        }
        public static Assembly GetClientAssemblies()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
