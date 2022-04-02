#pragma checksum "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af89d61801dd863b5bca71c1fb8a87d237f50f1a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CategoryTree_CategoryEdit), @"mvc.1.0.view", @"/Areas/Admin/Views/CategoryTree/CategoryEdit.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af89d61801dd863b5bca71c1fb8a87d237f50f1a", @"/Areas/Admin/Views/CategoryTree/CategoryEdit.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_CategoryTree_CategoryEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.ViewModels.AdminViewModel.CategoryTree.CategoryEditVM>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
  
    ViewData["Title"] = "CategoryEdit";
    Layout = "~/Views/Shared/_AdminLayoutPage1.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""content"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""card "">
                <div class=""card-header"">
                    <h2 class=""card-title"">Kategori Düzenle</h2>
                </div>
                <div class=""card-body"">

                    <div class=""row"">
                        <div class=""col-md-12"">
");
#nullable restore
#line 20 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                             using (Html.BeginForm("CategoryEdit", "CategoryTree"))
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                           Write(Html.HiddenFor(x => x.CategorySpeficationDTO.Category.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                           Write(Html.HiddenFor(x => x.CategorySpeficationDTO.Category.ParentCategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div>\r\n                                    ");
#nullable restore
#line 25 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                               Write(Html.TextBoxFor(x => x.CategorySpeficationDTO.Category.CategoryName, new { @class = "form-control col-md-5" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                                <div class=\"pt-4\">\r\n                                    <input type=\"submit\" value=\"Kaydet\" class=\"btn btn-outline-default\" />\r\n                                </div>\r\n");
#nullable restore
#line 30 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <div class=\"col-md-12\">\r\n                            <br /><br /><br />\r\n                            <h3 class=\"card-title\" style=\"font-weight:100;\">Filitre Ekle</h3><br />\r\n");
#nullable restore
#line 35 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                             using (Html.BeginForm("CategoryFilterCreate", "CategoryTree"))
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                           Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"d-flex\">\r\n                                    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 1855, "\"", 1904, 1);
#nullable restore
#line 39 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
WriteAttributeValue("", 1863, Model.CategorySpeficationDTO.Category.Id, 1863, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"CategorySpefication.CategoryId\" />\r\n                                    ");
#nullable restore
#line 40 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                               Write(Html.DropDownListFor(model => model.CategorySpefication.SpeficationAttributeId, Model.SpeficationAttributeSelectList, new { @class = " form-control col-md-5  " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    <input type=\"submit\" class=\"btn btn-outline-default ml-2\" value=\"Ekle\" />\r\n                                </div>\r\n");
#nullable restore
#line 44 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <br /><br /><br />\r\n                            <h3 class=\"card-title\" style=\"font-weight:100;\">Kategori Filitreleri</h3><br />\r\n\r\n");
#nullable restore
#line 48 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                             if (Model.CategorySpeficationDTO.CategorySpeficationList.Count != 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <table class=""table table-responsive"" stlye=""width:100%"">
                                    <thead>
                                        <tr>Özellik</tr>
                                        <tr> </tr>
                                    </thead>

");
#nullable restore
#line 56 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                                     foreach (var item in Model.CategorySpeficationDTO.CategorySpeficationList)
                                    {



#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td class=\"col-md-3\">");
#nullable restore
#line 61 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                                                            Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td><a");
            BeginWriteAttribute("href", " href=\"", 3250, "\"", 3373, 4);
            WriteAttributeValue("", 3257, "/Admin/CategoryTree/CategoryFilterDelete?speficationId=", 3257, 55, true);
#nullable restore
#line 62 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
WriteAttributeValue("", 3312, item.Id, 3312, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3320, "&categoryId=", 3320, 12, true);
#nullable restore
#line 62 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
WriteAttributeValue("", 3332, Model.CategorySpeficationDTO.Category.Id, 3332, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-danger\">Sil</a></td>\r\n                                        </tr>\r\n");
#nullable restore
#line 64 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </table>\r\n");
#nullable restore
#line 68 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                            }
                            else
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"text-center\"><div><hr /> Categoriye Ait Filitre Yok<hr /></div></span>\r\n");
#nullable restore
#line 73 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\CategoryTree\CategoryEdit.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.ViewModels.AdminViewModel.CategoryTree.CategoryEditVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
