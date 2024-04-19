using Core.Extension;
using Core.Utilities.Helper;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
namespace Core.Utilities.Generate
{
    public static class ApiGenerator
    {
        public static void GenerateApi(Assembly assembly)
        {
            try
            {
                foreach (var item in GetAllAssemblyClass(assembly))
                {
                    var parameterReferenceList = GetParameterReferenceList(item);
                    var controllerText = GetControllerText(item);
                    if (GetMethods(item, out var methods))
                    {
                        foreach (var methodInfo in methods)
                        {
                            var isAllowAnonymous = methodInfo.GetCustomAttributes<ApiGenerateAllowAnonymous>().Any() ? "[AllowAnonymous]" : "";
                            parameterReferenceList.AddRange((methodInfo.GetParameters().ToList()).Select(x => x.ParameterType.Namespace));
                            var parameterList = methodInfo.GetParameters().ToList();
                            var parameterMethod = String.Join(",", parameterList.Select(x => x.ParameterType.Name + " " + x.Name));
                            var pushParams = String.Join(",", parameterList.Select(x => x.Name));
                            if ((methodInfo.Name.Contains("Get") || methodInfo.Name.Contains("get")) &&
                                !methodInfo.Name.Contains("DataTable")
                                )
                            {
                                controllerText += GenerateQueryControllerString(parameterMethod, methodInfo, item, pushParams, isAllowAnonymous);
                            }
                            else
                            {
                                controllerText += GenerateCommandControllerString(parameterMethod, methodInfo, item, pushParams, isAllowAnonymous);
                            }
                        }
                        var parameterReferenceListJoin = String.Join("\n", parameterReferenceList.Distinct().Select(x => "using " + x + ";"));
                        controllerText = parameterReferenceListJoin + controllerText + "}}";
                        var path = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent + "\\Plugins\\Plugin.Api\\Controllers\\" + item.Name + "Controller.cs";
                        TextFileHelper.CreateFile(path, controllerText.FormatCsharpDocumentCode());
                    }
                }
                RunBatFile();
            }
            catch (Exception ex)
            {
                Log.Warning(ex.ToString());
            }
        }
        private static void RunBatFile()
        {
            var batPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent + "\\Plugins\\Plugin.Api\\build.bat";
            System.Diagnostics.ProcessStartInfo p = new(batPath);
            System.Diagnostics.Process proc = new() { StartInfo = p };
            proc.Start();
            proc.WaitForExit();
        }
        private static string GenerateQueryControllerString(string parameterMethod, MethodInfo methodInfo, Type item, string pushParams, string isAllowAnonymous)
        {
            parameterMethod = String.IsNullOrWhiteSpace(parameterMethod) ? parameterMethod : "[FromQuery]" + parameterMethod;
            return $@"{isAllowAnonymous}
                      [Produces(""application/json"", ""text/plain"")]
                      [HttpGet(""{methodInfo.Name.ToLowerInvariant()}"")]
                      [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
                      public async Task<IActionResult> {methodInfo.Name} ({parameterMethod}) {{
                           var result = await {"_" + item.Name.FirstCharToLowerCase()}.{methodInfo.Name}({pushParams});
                           if(result.Success)
                               return Ok(result.Data);
                           else
                               return BadRequest(result.Message);
                      }}";
        }
        private static string GenerateCommandControllerString(string parameterMethod, MethodInfo methodInfo, Type item, string pushParams, string isAllowAnonymous)
        {
            var modelBinding = methodInfo.GetCustomAttributes<GenerateApiFromFromAttribute>().Any() ? "[FromForm]" : "[FromBody]";
            return $@"{isAllowAnonymous}
                       [Produces(""application/json"", ""text/plain"")]
                       [HttpPost(""{methodInfo.Name.ToLowerInvariant()}"")]
                       [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
                       public async Task<IActionResult> {methodInfo.Name} ({modelBinding}{parameterMethod}) {{
                            var result = await {"_" + item.Name.FirstCharToLowerCase()}.{methodInfo.Name}({pushParams});
                            if(result.Success)
                                return Ok(result);
                            else
                                return BadRequest(result.Message);
                       }}";
        }
        private static List<string> GetParameterReferenceList(Type assemblyClass)
        {
            var parameterReferenceList = new List<string>();
            parameterReferenceList.AddRange(new List<string>
                {
                    "System", "System.Collections.Generic","System.Text","Core.Utilities.PagedList","Microsoft.AspNetCore.Mvc",
                    assemblyClass.Namespace,"Microsoft.AspNetCore.Http","System.Threading.Tasks","Microsoft.AspNetCore.Authorization","Core.Utilities.Identity"
                });
            return parameterReferenceList;
        }
        private static bool GetMethods(Type assemblyClass, out IEnumerable<MethodInfo> methods)
        {
            methods = assemblyClass.GetMethods().Where(x => x.DeclaringType.Name != "EfEntityRepositoryBase`2" && x.Module.Name != "System.Private.CoreLib.dll");
            return methods.Any();
        }
        private static IEnumerable<Type> GetAllAssemblyClass(Assembly assembly)
        {
            var data = assembly.GetTypes().Where(x =>
                x.IsClass && x.IsPublic && x.FullName.Contains("Business.Services"))
             .Where(type => !Attribute.IsDefined(type, typeof(IgnoreGeneratorAttribute)));
            return data;
        }
        private static string GetControllerText(Type item)
        {
            return $@"namespace eCommerce.Areas.Api {{
                        [AuthorizeControl]
                        [Route(""api/[controller]"")]
                        [ApiController]
                        public class {item.Name}Controller : ControllerBase{{
                             private readonly I{item.Name} {"_" + item.Name.FirstCharToLowerCase()};
                             public {item.Name}Controller(I{item.Name} {item.Name.FirstCharToLowerCase()}){{
                                {"_" + item.Name.FirstCharToLowerCase()}={item.Name.FirstCharToLowerCase()};
                             }}
                      ";
        }
    }
}
