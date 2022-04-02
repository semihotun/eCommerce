#pragma checksum "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6be478b300cfffa1265425586e51eb2604734c8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Checkout), @"mvc.1.0.view", @"/Views/Home/Checkout.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\_ViewImports.cshtml"
using eCommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\_ViewImports.cshtml"
using Entities.ViewModels.WebViewModel.IdentityModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6be478b300cfffa1265425586e51eb2604734c8b", @"/Views/Home/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5447bb8f95c55c30b7e3c9dc691c9731210c3ad2", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Checkout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.DTO.Product.Checkout>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("checkout-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("clearfix"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
  
    ViewBag.Title = "Checkout";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- BREADCRUMB -->
<div id=""breadcrumb"">
    <div class=""container"">
        <ul class=""breadcrumb"">
            <li><a href=""#"">Home</a></li>
            <li class=""active"">Checkout</li>
        </ul>
    </div>
</div>
<!-- /BREADCRUMB -->
<!-- section -->
<div class=""section"">
    <!-- container -->
    <div class=""container"">
        <!-- row -->
        <div class=""row"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6be478b300cfffa1265425586e51eb2604734c8b4663", async() => {
                WriteLiteral(@"




                <div class=""col-md-12"">
                    <div class=""order-summary clearfix"">
                        <div class=""section-title"">
                            <h3 class=""title"">Siparişler</h3>
                        </div>
                        <table class=""shopping-cart-table table"">
                            <tbody>

");
#nullable restore
#line 36 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
                                 if (Model.CheckoutProductList != null)
                                {
                                    foreach (var item in Model.CheckoutProductList)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <tr>\r\n                                            <td><strong>");
#nullable restore
#line 41 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
                                                   Write(item.ProductModel.ProductName);

#line default
#line hidden
#nullable disable
                WriteLiteral("  ");
#nullable restore
#line 41 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
                                                                                   Write(item.ProductCombinationText);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong></td>\r\n\r\n");
                WriteLiteral(@"                                            <td class=""details"">
                                            </td>
                                            <td class="" text-center"">
                                                Stokda
                                                ");
#nullable restore
#line 48 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
                                           Write(item.ProductStock.ProductStockPiece);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                <br /> adet kaldı\r\n                                            </td>\r\n\r\n\r\n\r\n                                            <td class=\"text-center\">Adet Fiyatı ");
#nullable restore
#line 54 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
                                                                           Write(item.ProductStock.ProductPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral(" TL</td>\r\n\r\n\r\n                                            <td class=\"qty text-center\">\r\n                                                <input class=\"input\" type=\"number\"");
                BeginWriteAttribute("value", " value=\"", 2227, "\"", 2253, 1);
#nullable restore
#line 58 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
WriteAttributeValue("", 2235, item.ProductPiece, 2235, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("max", " max=\"", 2254, "\"", 2296, 1);
#nullable restore
#line 58 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
WriteAttributeValue("", 2260, item.ProductStock.ProductStockPiece, 2260, 36, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" min=\"0\">\r\n\r\n                                            </td>\r\n\r\n                                            <td>Toplam Fiyat <span class=\"price\">");
#nullable restore
#line 62 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
                                                                            Write(item.ProductPieceTotalPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> TL</td>\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 65 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"

                                    }
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"7\" style=\"text-align:center;background-color:#F6F7F8;\">Sepetiniz boş</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </tbody>

                        </table>
                        <table class=""shopping-cart-table table"">
                            <tfoot style=""float:right"">
                                <tr>                            
                                    <th>Toplam Tutar</th>
                                    <th colspan=""2"" class=""total"">");
#nullable restore
#line 81 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Views\Home\Checkout.cshtml"
                                                             Write(Model.AllProductTotalPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" TL</th>
                                </tr>
                            </tfoot>
                        </table>
                        <div class=""pull-right"">
                            <button class=""primary-btn"">Devam Et</button>
                        </div>
                    </div>

                </div>

            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n        <!-- /row -->\r\n    </div>\r\n    <!-- /container -->\r\n</div>\r\n<!-- /section -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.DTO.Product.Checkout> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
