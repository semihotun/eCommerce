#pragma checksum "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProductAttr\AttrCreate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7d486016de3c336faf4a5d270d4edcca35d6c3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminProductAttr_AttrCreate), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminProductAttr/AttrCreate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7d486016de3c336faf4a5d270d4edcca35d6c3e", @"/Areas/Admin/Views/AdminProductAttr/AttrCreate.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_AdminProductAttr_AttrCreate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.Concrete.ProductAggregate.ProductAttribute>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProductAttr\AttrCreate.cshtml"
  

    ViewData["Title"] = "AttrCreate";
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
                    <div class=""col-md-4"" style=""float:left;"">
                        <h2 class=""card-title"">Özellik Ekle</h2>
                    </div>

                </div>
                <div class=""card-body"">

");
#nullable restore
#line 21 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProductAttr\AttrCreate.cshtml"
                     using (Html.BeginForm("AttrCreate", "AdminProductAttr", FormMethod.Post))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div style=\"display:flex;flex-wrap:wrap;\">\r\n                            ");
#nullable restore
#line 24 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProductAttr\AttrCreate.cshtml"
                       Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <div class=\"form-group col-md-12\">\r\n                                ");
#nullable restore
#line 26 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProductAttr\AttrCreate.cshtml"
                           Write(Html.LabelFor(x => x.Name, "İsmi", new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                <div class=\"col-md-10\">\r\n                                    ");
#nullable restore
#line 29 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProductAttr\AttrCreate.cshtml"
                               Write(Html.TextBoxFor(x => x.Name, new { @class = "form-control  col-md-8" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n\r\n\r\n                            <div class=\"form-group col-md-12\">\r\n                                ");
#nullable restore
#line 35 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProductAttr\AttrCreate.cshtml"
                           Write(Html.LabelFor(x => x.Description, "Açıklama", new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                <div class=\"col-md-10\">\r\n                                    ");
#nullable restore
#line 38 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProductAttr\AttrCreate.cshtml"
                               Write(Html.TextBoxFor(x => x.Description, new { @class = "form-control  col-md-8" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>

                            <div class=""form-group col-md-12"">


                                <div class=""col-md-10"">
                                    <input type=""submit"" class=""btn btn-default"" />
                                </div>
                            </div>


                        </div>
");
#nullable restore
#line 52 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProductAttr\AttrCreate.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.Concrete.ProductAggregate.ProductAttribute> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
