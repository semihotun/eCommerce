using ApiGenerator.Extension;
using Business.Extension;
using System;
using System.Linq;
using System.Reflection;

namespace ApiGenerators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenerateApi();
            Console.ReadKey();
        }
        static void GenerateApi()
        {
            var projectDirectoryParts = Assembly.GetExecutingAssembly().Location.Split('\\');
            var projectDirectory = string.Join("\\", projectDirectoryParts.Take(projectDirectoryParts.Length - 6));
            var path = projectDirectory + "\\eCommerceApi\\";
            if (Generator.GenerateApi(BusinessAssembliesExtension.GetBusinessAssemblies(), path))
            {
                Console.WriteLine("Bütün Controllerlar Generate Edildi");
            }
            else
            {
                Console.WriteLine("Generate Ederken Bir hata oluştu");
            }
        }
    }
}
