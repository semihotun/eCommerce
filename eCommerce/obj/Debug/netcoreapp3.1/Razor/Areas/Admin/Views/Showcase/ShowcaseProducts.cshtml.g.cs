#pragma checksum "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75f145eb7feb861abc676c1250582270c0839a15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Showcase_ShowcaseProducts), @"mvc.1.0.view", @"/Areas/Admin/Views/Showcase/ShowcaseProducts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75f145eb7feb861abc676c1250582270c0839a15", @"/Areas/Admin/Views/Showcase/ShowcaseProducts.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Showcase_ShowcaseProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.ViewModels.AdminViewModel.Showcase.ShowCaseCreateOrUpdateVM>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"table-responsive\">\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
#nullable restore
#line 10 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
     using (Html.BeginForm("ShowcaseEdit", "ShowCase",FormMethod.Get,new { Tap = "tap3", Id = "ProductListForm" }))
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"hidden\" name=\"Tap\" value=\"tab3\" class=\"tabsaklayici\"/>\r\n        <div style=\"display:flex;flex-wrap:wrap;\">\r\n            <div class=\"form-group col-md-6 row\">\r\n\r\n                <input type=\"hidden\" name=\"id\"");
            BeginWriteAttribute("value", " value=\"", 477, "\"", 506, 1);
#nullable restore
#line 17 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
WriteAttributeValue("", 485, Model.ShowCaseDto.Id, 485, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                ");
#nullable restore
#line 18 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
           Write(Html.LabelFor(x => x.ProductModel.Id, "Id", new { @class = "control-label col-md-2 " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"col-md-10 \">\r\n                    ");
#nullable restore
#line 21 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
               Write(Html.TextBoxFor(model => model.ProductModel.Id, new { @class = " form-control  " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n            </div>\r\n            <br />\r\n            <div class=\"form-group col-md-6 row\">\r\n                ");
#nullable restore
#line 27 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
           Write(Html.LabelFor(x => x.ProductModel.ProductName, "Ürün İsmi", new { @class = "control-label col-md-2 " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"col-md-10 \">\r\n                    ");
#nullable restore
#line 30 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
               Write(Html.TextBoxFor(model => model.ProductModel.ProductName, new { @class = " form-control " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n            </div>\r\n            <br />\r\n            <div class=\"form-group col-md-6 row\">\r\n                ");
#nullable restore
#line 36 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
           Write(Html.LabelFor(x => x.ProductModel.BrandId, "Marka", new { @class = "control-label col-md-2 " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"col-md-10 \">\r\n                    ");
#nullable restore
#line 39 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
               Write(Html.DropDownListFor(model => model.ProductModel.BrandId,Model.BrandSelectListItems, new { @class = " form-control  " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n            </div>\r\n            <br />\r\n            <div class=\"form-group col-md-6 row\">\r\n                ");
#nullable restore
#line 45 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
           Write(Html.LabelFor(x => x.ProductModel.CategoryId, "Kategori", new { @class = "control-label col-md-2 " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"col-md-10 \">\r\n                    ");
#nullable restore
#line 48 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
               Write(Html.DropDownListFor(model => model.ProductModel.CategoryId, Model.CategorySelectListItems, new { @class = " form-control  " }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                </div>
            </div>
            <br />    <br />    <br />
            <div class=""form-group col-md-12 row"">

                <button type=""submit"" class=""btn  btnsearch btn-default "" onclick=""BindProductList();"">Ara</button>&nbsp;&nbsp;
                <button type=""reset"" class=""btn btn-dark"">Sıfırla</button>
            </div>
        </div>
");
#nullable restore
#line 59 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


    <div class=""table-responsive ps ps--active-x"">


        <table id=""ProductList"" class=""table tablesorter table-hover dt-responsive nowrapr"" width=""100%"" cellspacing=""0"">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>İsim</th>
                    <th>Marka</th>
                    <th>Kategori</th>
                    <th>Btn</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>


    <script>
        var ProductListTableo;
        var BindProductList = function (response) {
            if ($.fn.DataTable.isDataTable(""#ProductList"")) {
                ProductListTableo.draw();

            }
            else {

                ProductListTableo = $(""#ProductList"").DataTable({
                    ""sAjaxSource"": ""/Admin/AdminProduct/ProductListJson?id=""
                        + $(""#ProductModel_Id"").val()
                        + ""&ProductName="" + $(""#Produ");
            WriteLiteral(@"ctModel_ProductName"").val()
                        + ""&CategoryId="" + $(""#ProductModel_CategoryId"").val()
                        + ""&BrandModel.Id="" + $(""#ProductModel_BrandId"").val(),
                    ""bServerSide"": true,
                    ""bProcessing"": true,
                    ""bSearchable"": true,
                    ""bLengthChange"": false,
                    ""searching"": false,
                    ""columns"": [
                        { ""data"": ""Id"", ""name"": ""Id"", ""autoWidth"": true },
                        { ""data"": ""ProductName"", ""name"": ""ProductName"", ""autoWidth"": true },
                        { ""data"": ""BrandName"", ""name"": ""BrandId"", ""autoWidth"": true },
                        { ""data"": ""CategoryName"", ""name"": ""CategoryId"", ""autoWidth"": true },
                        {
                            data: null,
                            render: function (data, type, row) {
                                return ""<a href='/Admin/Showcase/ShowcaseAdded?productid="" + row.Id +");
            WriteLiteral("\n                                    \"&showcaseid=\" +");
#nullable restore
#line 111 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\Showcase\ShowcaseProducts.cshtml"
                                               Write(Model.ShowCaseDto.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"+
                                    ""&combinationId="" + (row.ProductAttributeCombination != null ? row.ProductAttributeCombination.Id : 0) +
                                    ""' class='btn btn btn-outline-default'  >Ekle</a>"";
                            }, ""orderable"": false
                        }
                    ], ""language"": {
                        ""url"": ""/datatablelanguage.json""
                    }

                });

            }

        }


        var FilterRecord = function () {
            BindProductList();
        }
        $(document).ready(function () {
            BindProductList();

        });
        $(""#ProductListForm"").submit(function (event) {
            event.preventDefault();
            $('#ProductList').DataTable().destroy();
            BindProductList();
        });
    </script>



</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.ViewModels.AdminViewModel.Showcase.ShowCaseCreateOrUpdateVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
