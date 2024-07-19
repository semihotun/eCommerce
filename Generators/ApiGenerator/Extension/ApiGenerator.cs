using Core.Extension;
using Core.Utilities.Aspects.Autofac.Secure;
using Core.Utilities.Generate;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace ApiGenerator.Extension
{
    public static class Generator
    {
        public static bool GenerateApi(Assembly assembly, string path)
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
                            //Console.WriteLine(methodInfo.Name);
                            var isAllowAnonymous = methodInfo.GetCustomAttributes<ApiGenerateAllowAnonymous>().Any() ||
                                !methodInfo.CustomAttributes.Where(x => x.AttributeType.Name == "AuthAspect").Any() ? "[AllowAnonymous]" : "";
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
                        TextFileHelper.CreateFile(path + "Controllers\\" + item.Name + "Controller.cs", controllerText.FormatCsharpDocumentCode());
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Warning(ex.ToString());
                return false;
            }
        }
        private static string GenerateQueryControllerString(string parameterMethod, MethodInfo methodInfo, Type item, string pushParams, string isAllowAnonymous)
        {
            var returnTypeText = GetReadableTypeName(methodInfo.ReturnType,true);
            parameterMethod = String.IsNullOrWhiteSpace(parameterMethod) ? parameterMethod : "[FromQuery]" + parameterMethod;
            return $@"{isAllowAnonymous}
                      [Produces(""application/json"", ""text/plain"")]
                      [HttpGet(""{methodInfo.Name.ToLowerInvariant()}"")]
                      [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
                      [ProducesResponseType(StatusCodes.Status200OK, Type = typeof({returnTypeText}))]
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
            var returnTypeText = GetReadableTypeName(methodInfo.ReturnType);
            var modelBinding = methodInfo.GetCustomAttributes<GenerateApiFromFromAttribute>().Any() ? "[FromForm]" : "[FromBody]";
            return $@"{isAllowAnonymous}
                       [Produces(""application/json"", ""text/plain"")]
                       [HttpPost(""{methodInfo.Name.ToLowerInvariant()}"")]
                       [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
                       [ProducesResponseType(StatusCodes.Status200OK, Type = typeof({returnTypeText}))]
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
                x.IsClass && x.IsPublic && x.FullName.Contains("Business.Services") && x.Name.Contains("Service"))
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
        public static string GetReadableTypeName(Type type, bool isNotRead = false)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>))
            {
                return GetReadableTypeName(type.GetGenericArguments()[0], isNotRead).Replace("+", ".");
            }
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Result<>) && isNotRead)
            {
                return GetReadableTypeName(type.GetGenericArguments()[0], isNotRead).Replace("+", ".");
            }
            if (type.IsArray)
            {
                string elementTypeName = GetReadableTypeName(type.GetElementType(), isNotRead).Replace("+", ".");
                return $"{elementTypeName}[]";
            }
            if (type.IsGenericType)
            {
                string typeName = type.GetGenericTypeDefinition().FullName;
                if (type.GetGenericTypeDefinition() == typeof(Result<>) && isNotRead)
                {
                    return $"{string.Join(", ", Array.ConvertAll(type.GetGenericArguments(), t => GetReadableTypeName(t, isNotRead))).Replace("+", ".")}";
                }
                string genericArguments = string.Join(", ", Array.ConvertAll(type.GetGenericArguments(), t => GetReadableTypeName(t, isNotRead))).Replace("+", ".");
                return $"{typeName.Substring(0, typeName.IndexOf('`'))}<{genericArguments}>";
            }
            return type.Name switch
            {
                "Int32" => "int",
                "Int64" => "long",
                "Int16" => "short",
                "UInt32" => "uint",
                "UInt64" => "ulong",
                "UInt16" => "ushort",
                "Boolean" => "bool",
                "String" => "string",
                "Object" => "object",
                "Void" => "void",
                _ => type.FullName
            };
        }

    }
}
