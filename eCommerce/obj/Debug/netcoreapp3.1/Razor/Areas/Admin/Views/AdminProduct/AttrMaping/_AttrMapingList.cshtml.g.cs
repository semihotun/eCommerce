#pragma checksum "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d416d6041c585bbc28f6bd1512c6194d509431ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminProduct_AttrMaping__AttrMapingList), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminProduct/AttrMaping/_AttrMapingList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d416d6041c585bbc28f6bd1512c6194d509431ae", @"/Areas/Admin/Views/AdminProduct/AttrMaping/_AttrMapingList.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_AdminProduct_AttrMaping__AttrMapingList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.ViewModels.AdminViewModel.AdminProduct.ProductVM>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<br />\r\n\r\n\r\n<div class=\"accordion\" id=\"accordion\">\r\n");
#nullable restore
#line 6 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
     if (Model.ProductAttributeMappingList! != null)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
         foreach (var item in Model.ProductAttributeMappingList)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card p-0 m-0 border border-secondary\"\r\n                 ");
#nullable restore
#line 12 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                   var cardMappingId = "Mappingcard" + item.Id; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                 id=\"");
#nullable restore
#line 13 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                Write(cardMappingId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n");
#nullable restore
#line 14 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                   var collapseHeadingId = "collapseHeading" + item.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card-header p-0 d-flex  position-relative\"");
            BeginWriteAttribute("id", " id=\"", 571, "\"", 594, 1);
#nullable restore
#line 15 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
WriteAttributeValue("", 576, collapseHeadingId, 576, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 16 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                       var mappingButtonId = "MappingButton" + item.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                       var collapseIdHashtag = "#collapse" + item.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <button type=\"button\" class=\"btn text-left w-100 p-4 btn-neutral d-flex\"");
            BeginWriteAttribute("onclick", " onclick=\"", 838, "\"", 877, 3);
            WriteAttributeValue("", 848, "GetMappingAttribute(", 848, 20, true);
#nullable restore
#line 19 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
WriteAttributeValue("", 868, item.Id, 868, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 876, ")", 876, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 878, "\"", 899, 1);
#nullable restore
#line 19 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
WriteAttributeValue("", 883, mappingButtonId, 883, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                            data-toggle=\"collapse\" data-target=\"");
#nullable restore
#line 20 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                                                           Write(collapseIdHashtag);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"False\" aria-controls=\"collapseOne\">\r\n                        <span class=\"vertical-absolute-left-center ml-4\">\r\n                            ");
#nullable restore
#line 22 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                       Write(item.TextPrompt);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </span>\r\n\r\n                    </button>\r\n                    <span class=\"h1 vertical-absolute-right-center mr-4\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\'", 1326, "\'", 1427, 1);
#nullable restore
#line 27 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
WriteAttributeValue("", 1333, Url.Action("AttrAttributeValueList", "AdminProductAttr", new {ProductAttrMapingId = item.Id}), 1333, 94, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-default\">\r\n                            <i class=\"fas fa-edit\"></i>\r\n                        </a>\r\n                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1576, "\"", 1612, 3);
            WriteAttributeValue("", 1586, "AttrMapingDelete(", 1586, 17, true);
#nullable restore
#line 30 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
WriteAttributeValue("", 1603, item.Id, 1603, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1611, ")", 1611, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-default\">\r\n                            <i class=\"fas fa-remove\"></i>\r\n                        </a>\r\n                    </span>\r\n                </div>\r\n");
#nullable restore
#line 35 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                   var collapseId = "collapse" + item.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("id", " id=\"", 1870, "\"", 1886, 1);
#nullable restore
#line 36 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
WriteAttributeValue("", 1875, collapseId, 1875, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\"");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 1904, "\"", 1940, 1);
#nullable restore
#line 36 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
WriteAttributeValue("", 1922, collapseHeadingId, 1922, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-parent=\"#accordion\">\r\n                    <div class=\"card-body border border-secondary\">\r\n");
#nullable restore
#line 38 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                           var mappingTableId = "MappingTable" + item.Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <table class=\"table table-hover tablesorter\"");
            BeginWriteAttribute("id", " id=\"", 2182, "\"", 2202, 1);
#nullable restore
#line 39 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
WriteAttributeValue("", 2187, mappingTableId, 2187, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <thead>
                                <tr>
                                    <td>İsim</td>
                                    <td>Seçili gelsin</td>
                                    <td>Sıralaması</td>
                                    <td> </td>
                                </tr>
                            </thead>
                            <tbody>
                                <input type=""button"" class=""btn btn btn-outline-default mt-3 mb-3""
                                       value=""Attribute Ekle""");
            BeginWriteAttribute("onclick", "\r\n                                       onclick=\"", 2772, "\"", 2863, 3);
            WriteAttributeValue("", 2822, "ChangeTextboxAttributeMappingId(", 2822, 32, true);
#nullable restore
#line 51 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
WriteAttributeValue("", 2854, item.Id, 2854, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2862, ")", 2862, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                            </tbody>\r\n                        </table>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 59 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"


        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>



<div class=""modal  bd-example-modal-xl mx-auto"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myExtraLargeModalLabel"" aria-hidden=""true"" id=""productMappingAttributeValueModal"">
    <div class="" modal-xl"" style=""margin: 5%;"">
        <div class=""modal-content"" style=""padding: 30px;"">
            <form id=""MappingAttributeCreate"">
                <table cellpadding=""4"" style=""width: 90%;"" class=""mx-auto"">

                    <tbody>
                        <tr>
                            <td><h3>Product Alt çapraz ürün özelliği ekle</h3></td>
                            <td>
                                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                    <span aria-hidden=""true"" style=""font-size: 30px;"">&times;</span>
                                </button>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <");
            WriteLiteral("td>");
#nullable restore
#line 84 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                           Write(Html.HiddenFor(x => x.ProductAttributeValue.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td></td>\r\n                            <td>");
#nullable restore
#line 88 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                           Write(Html.HiddenFor(x => x.ProductAttributeValue.ProductAttributeMappingId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"w-40\">İsmi</td>\r\n                            <td class=\"w-50\">\r\n                                ");
#nullable restore
#line 93 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                           Write(Html.TextBoxFor(x => x.ProductAttributeValue.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <br />\r\n                                ");
#nullable restore
#line 95 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                           Write(Html.ValidationMessageFor(x => x.ProductAttributeValue.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"w-40\">Kare rengi</td>\r\n                            <td class=\"w-50\">\r\n                                ");
#nullable restore
#line 101 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                           Write(Html.TextBoxFor(x => x.ProductAttributeValue.ColorSquaresRgb, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <br />\r\n                                ");
#nullable restore
#line 103 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                           Write(Html.ValidationMessageFor(x => x.ProductAttributeValue.ColorSquaresRgb));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"w-40\">Sıresı</td>\r\n                            <td class=\"w-50\">\r\n                                ");
#nullable restore
#line 109 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                           Write(Html.TextBoxFor(x => x.ProductAttributeValue.DisplayOrder, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <br />\r\n                                ");
#nullable restore
#line 111 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                           Write(Html.ValidationMessageFor(x => x.ProductAttributeValue.DisplayOrder));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>Seçili Gelsin</td>\r\n                            <td> ");
#nullable restore
#line 116 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\AttrMaping\_AttrMapingList.cshtml"
                            Write(Html.CheckBoxFor(x => x.ProductAttributeValue.IsPreSelected, new { onclick = "$(this).attr('value', this.checked ? true : false)", value = "false" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                        </tr>
                        <tr>
                            <td> <input type=""button"" class=""btn btn-default form-control col-md-5"" value=""Kaydet"" id=""register"" style=""color: white;"" onclick=""AddProductMappingAttributeValue()""></td>
                            <td></td>
                        </tr>

                    </tbody>

                </table>
            </form>
        </div>

    </div>
</div>











");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.ViewModels.AdminViewModel.AdminProduct.ProductVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
