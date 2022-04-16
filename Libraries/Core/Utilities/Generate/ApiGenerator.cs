using Core.Utilities.Attributes;
using Core.Utilities.Helper;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Generate
{
    public static class ApiGenerator
    {
        public static void GenerateApi()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var assembliesFilter = assemblies.Where(
                 x => x.ManifestModule.Name == "Business.dll" ||
                 x.ManifestModule.Name == "DataAccess.dll" ||
                 x.ManifestModule.Name == "Core.dll"
                 );
            var assemblyClass = assembliesFilter.SelectMany(x => x.GetTypes()
            .Where(x => x.IsClass == true && x.IsPublic == true &&
            (x.Name.ToLowerInvariant().Contains("service") ||
             x.Name.ToLowerInvariant().Contains("dal")) &&

             (x.FullName.Contains("Business.Services") ||
             x.FullName.Contains("DataAccess.DALs.EntitiyFramework") ||
             x.FullName.Contains("Core.Library.Business")) ||
             x.FullName.Contains("Core.Library.DAL"))

             );

            foreach (var item in assemblyClass)
            {
                var parameterReferenceList = new List<string>();
                parameterReferenceList.AddRange(new List<string>
                {
                    "System", "System.Collections.Generic","System.Text","X.PagedList","Microsoft.AspNetCore.Mvc",
                    item.Namespace,"Microsoft.AspNetCore.Http","System.Threading.Tasks","Microsoft.AspNetCore.Authorization","Core.Utilities.Identity"
                });

                var controllerText = $@" 
                        namespace eCommerce.Areas.Api {{
                            [AuthorizeControl]
                            [Route(""api/[controller]"")]
                            [ApiController]
                            public class {item.Name}Controller : ControllerBase{{
                                 private readonly I{item.Name} {"_" + item.Name.FirstCharToLowerCase()};

                                 public {item.Name}Controller(I{item.Name} {item.Name.FirstCharToLowerCase()}){{
                                    {"_" + item.Name.FirstCharToLowerCase()}={item.Name.FirstCharToLowerCase()};
                                 }}
                      ";
            
                var methods = item.GetMethods().Where(
                 x => x.DeclaringType.Name != "EfEntityRepositoryBase`2" &&
                 x.Module.Name != "System.Private.CoreLib.dll"
                 );


                if (methods.Count() > 0)
                {
                    foreach (var methodInfo in methods)
                    {
                        var isAllowAnonymous = methodInfo.GetCustomAttributes<ApiGenerateAllowAnonymous>().Count() > 0 ? "[AllowAnonymous]" : "";

                        var parameterReference = (methodInfo.GetParameters().ToList()).Select(x => x.ParameterType.Namespace);
                        parameterReferenceList.AddRange(parameterReference);
                        var parameterList = methodInfo.GetParameters().ToList();
                        var parameterMethod = String.Join(",", parameterList.Select(x => x.ParameterType.Name.ToString() + " " + x.Name));
                        var pushParmas = String.Join(",", parameterList.Select(x => x.Name));

                        if ((methodInfo.Name.Contains("Get") || methodInfo.Name.Contains("get")) &&
                            !methodInfo.Name.Contains("DataTable")
                            )
                        {
                            parameterMethod = String.IsNullOrWhiteSpace(parameterMethod) == true ? parameterMethod : "[FromQuery]" + parameterMethod;
                            controllerText += $@"
                                    {isAllowAnonymous}
                                    [Produces(""application/json"", ""text/plain"")]
                                    [HttpGet(""{methodInfo.Name.ToLowerInvariant()}"")]
                                    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
                                    public async Task<IActionResult> {methodInfo.Name} ({parameterMethod}) {{
                                 
                                         var result = await {"_" + item.Name.FirstCharToLowerCase()}.{methodInfo.Name}({pushParmas});
                                 
                                         if(result.Success)
                                             return Ok(result.Data);
                                         else
                                             return BadRequest(result.Message);
                                    }}                
                        ";
                        }
                        else
                        {
                            var returnSuccess = methodInfo.ReturnType.ToString().Contains("IResult") ? "return Ok(result.Success);" : "return Ok(result.Data);";
                                controllerText += $@"
                                    {isAllowAnonymous}
                                    [Produces(""application/json"", ""text/plain"")]
                                    [HttpPost(""{methodInfo.Name.ToLowerInvariant()}"")]
                                    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
                                    public async Task<IActionResult> {methodInfo.Name} ([FromBody]{parameterMethod}) {{
                                 
                                         var result = await {"_" + item.Name.FirstCharToLowerCase()}.{methodInfo.Name}({pushParmas});
                                 
                                         if(result.Success)
                                             {returnSuccess}
                                         else
                                             return BadRequest(result.Message);
                                 
                                     }}                
                             ";
                            
                           
                        }
                    }
                    var parameterReferenceListJoin = String.Join("\n", parameterReferenceList.Distinct().Select(x => "using " + x.ToString() + ";"));
                    controllerText = parameterReferenceListJoin + controllerText;
                    controllerText += $@"     
                                 }}
                        }}";

                    var solutionPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent;
                    var path=solutionPath + "\\Plugins\\Plugin.Api\\Controllers\\"+ item.Name + "Controller.cs";

                    TextFileHelper.CreateFile(path, RegexHelper.RemoveFromTap(controllerText));

                }
            }
            var batDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent;
            var batPath = batDirectory + "\\Plugins\\Plugin.Api\\build.bat";

            System.Diagnostics.ProcessStartInfo p = new System.Diagnostics.ProcessStartInfo(batPath);
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = p;
            proc.Start();
            proc.WaitForExit();
        }







    }

}


