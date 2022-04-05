using Core.Utilities.Helper;
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
                 x.ManifestModule.Name == "DataAccess.dll"
                 );
            var assemblyClass = assembliesFilter.SelectMany(x => x.GetTypes()
            .Where(x => x.IsClass == true && x.IsPublic == true &&
            (x.Name.ToLowerInvariant().Contains("service") || x.Name.ToLowerInvariant().Contains("dal")) &&
            (x.FullName.Contains("Business.Services") || x.FullName.Contains("DataAccess.DALs.EntitiyFramework"))
            
            ));

            //Aynı Method ismi çakışabilir
            var assemblyClassGroup= assemblyClass.GroupBy(x => x.Name.Replace("DAL", "").Replace("Service", ""));

            foreach (var item in assemblyClass)
            {
                var parameterReferenceList = new List<string>();
                parameterReferenceList.AddRange(new List<string>
                {
                    "System", "System.Collections.Generic","System.Text","X.PagedList","Microsoft.AspNetCore.Mvc",
                    item.Namespace,"Microsoft.AspNetCore.Http","System.Threading.Tasks"
                });

                var controllerText = $@" 
                        namespace eCommerce.Areas.Api {{

                            [Route(""api/[controller]"")]
                            [ApiController]
                            public class {item.Name}Controller : ControllerBase{{
                                 private readonly I{item.Name} {"_" + item.Name.FirstCharToLowerCase()};

                                 public {item.Name}Controller(I{item.Name} {item.Name.FirstCharToLowerCase()}){{
                                    {"_" + item.Name.FirstCharToLowerCase()}={item.Name.FirstCharToLowerCase()};
                                 }}
                      ";
                var methods = item.GetMethods().Where(
                     x => x.Module.Name == "Business.dll" ||
                     x.Module.Name == "DataAccess.dll"
                    );

                if (methods.Count() > 0)
                {
                    foreach (var methodInfo in methods)
                    {
                        var parameterReference = (methodInfo.GetParameters().ToList()).Select(x => x.ParameterType.Namespace);
                        parameterReferenceList.AddRange(parameterReference);
                        var parameterList = methodInfo.GetParameters().ToList();
                        var parameterMethod = String.Join(",", parameterList.Select(x => x.ParameterType.Name.ToString() + " " + x.Name));
                        var pushParmas = String.Join(",", parameterList.Select(x => x.Name));

                        if ((methodInfo.Name.Contains("Get") || methodInfo.Name.Contains("get")) && !methodInfo.Name.Contains("DataTable"))
                        {
                            controllerText += $@"
                                    [Produces(""application/json"", ""text/plain"")]
                                    [HttpGet(""{methodInfo.Name.ToLowerInvariant()}"")]
                                    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
                                    public async Task<IActionResult> {methodInfo.Name} ({parameterMethod}) {{
                                 
                                         var result = await {"_" + item.Name.FirstCharToLowerCase()}.{methodInfo.Name}({pushParmas});
                                 
                                         if(result.Success)
                                             return Ok(result.Success);
                                         else
                                             return BadRequest(result.Message);
                                    }}                
                        ";
                        }
                        else
                        {
                            controllerText += $@"
                                    [Produces(""application/json"", ""text/plain"")]
                                    [HttpPost(""{methodInfo.Name.ToLowerInvariant()}"")]
                                    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
                                    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
                                    public async Task<IActionResult> {methodInfo.Name} ([FromBody]{parameterMethod}) {{
                                 
                                         var result = await {"_" + item.Name.FirstCharToLowerCase()}.{methodInfo.Name}({pushParmas});
                                 
                                         if(result.Success)
                                             return Ok(result.Success);
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

                    var path = Directory.GetCurrentDirectory() + "\\Areas\\Api\\" + item.Name + "Controller.cs";
                    TextFileHelper.CreateFile(path, RegexHelper.RemoveFromTap(controllerText));
                }
            }
        }







    }

}


