#pragma checksum "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "759b575feffea11d6c458475742d26bb1bd79b69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminProduct_ProductList), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminProduct/ProductList.cshtml")]
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
#line 1 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"759b575feffea11d6c458475742d26bb1bd79b69", @"/Areas/Admin/Views/AdminProduct/ProductList.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_AdminProduct_ProductList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.ViewModels.AdminViewModel.AdminProduct.ProductListVM>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" <!--import to get HTML Helper-->\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
  
    ViewBag.Title = "ProductList";
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
                        <h2 class=""card-title"">Ürün Listesi</h2>
                    </div>
                    <div class=""col-md-8"" style=""float:right;"">
                        <div class=""col-md-3"" style=""float:right;""><a type=""submit"" class=""btn btn-outline-default pd10-50"" style=""text-align:center;"" href=""/Admin/AdminProduct/ProductEdit?Id=0"">Ekle</a></div>

                    </div>
                </div>
                <div class=""card-body"">
                    <br />
                    <div class=""col-md-12"">
");
#nullable restore
#line 28 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                         using (Html.BeginForm("ProductList", "AdminProduct",FormMethod.Post ,new { Id = "ProductListForm" }))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div style=\"display:flex;flex-wrap:wrap;\">\r\n                                <div class=\"form-group col-md-6 row\">\r\n                                    ");
#nullable restore
#line 32 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                               Write(Html.LabelFor(x => x.Id, "Id", new { @class = "control-label col-md-2 " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    <div class=\"col-md-10 \">\r\n                                        ");
#nullable restore
#line 35 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                                   Write(Html.TextBoxFor(model => model.Id, new { @class = " form-control",Type="number",min="0" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    </div>\r\n                                </div>\r\n                                <br />\r\n                                <div class=\"form-group col-md-6 row\">\r\n                                    ");
#nullable restore
#line 41 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                               Write(Html.LabelFor(x => x.ProductName, "Ürün İsmi", new { @class = "control-label col-md-2 " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    <div class=\"col-md-10 \">\r\n                                        ");
#nullable restore
#line 44 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                                   Write(Html.TextBoxFor(model => model.ProductName, new { @class = " form-control " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    </div>\r\n                                </div>\r\n                                <br />\r\n                                <div class=\"form-group col-md-6 row\">\r\n                                    ");
#nullable restore
#line 50 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                               Write(Html.LabelFor(x => x.BrandId, "Marka", new { @class = "control-label col-md-2 " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    <div class=\"col-md-10 \">\r\n                                        ");
#nullable restore
#line 53 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                                   Write(Html.DropDownListFor(model => model.BrandId,Model.BrandSelectListItems, new { @class = " form-control  " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    </div>\r\n                                </div>\r\n                                <br />\r\n                                <div class=\"form-group col-md-6 row\">\r\n                                    ");
#nullable restore
#line 59 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                               Write(Html.LabelFor(x => x.CategoryId, "Kategori", new { @class = "control-label col-md-2 " }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    <div class=\"col-md-10 \">\r\n                                        ");
#nullable restore
#line 62 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                                   Write(Html.DropDownListFor(model => model.CategoryId,Model.CategorySelectListItems, new { @class = " form-control  " }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                    </div>
                                </div>
                                <br />    <br />    <br />
                                <div class=""form-group col-md-12 row"">

                                    <button type=""submit"" class=""btn btnsearch btn-default "" onclick=""BindProductList();"">Ara</button>&nbsp;&nbsp;
                                    <button type=""reset"" class=""btn btn-dark"">Sıfırla</button>

                                </div>
                            </div>
");
#nullable restore
#line 74 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                    </div>


                    <div class=""table-responsive"">


                        <br />

                        <div class=""table-responsive ps ps--active-x"">


                            <table id=""ProductList"" class=""table tablesorter table-hover dt-responsive nowrapr"" width=""100%"" cellspacing=""0"">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>İsim</th>
                                        <th>Marka</th>
                                        <th>Kategori</th>
                                        <th> </th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                        </div>


                        <div class=""content"">
                            ");
#nullable restore
#line 105 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\ProductList.cshtml"
                       Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>



                        <script>
                            var ProductListTableo;
                            var BindProductList = function (response) {
                                if ($.fn.DataTable.isDataTable(""#ProductList"")) {
                                    ProductListTableo.draw();

                                }
                                else {

                                    ProductListTableo = $(""#ProductList"").DataTable({
                                        ""sAjaxSource"": ""/Admin/AdminProduct/ProductListJson?Id="" + $(""#Id"").val()
                                            + ""&ProductName="" + $(""#ProductName"").val()
                                            + ""&CategoryId="" + $(""#CategoryId"").val()
                                            + ""&BrandModel.Id="" + $(""#BrandId"").val(),
                                        ""bServerSide"": true,
                                        ""bProcessing"": true,
          ");
            WriteLiteral(@"                              ""bSearchable"": true,
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
                                                    return ""<a href='#' id='"" + row.Id + ""' ><i class='fa fa-trash-o datatab");
            WriteLiteral(@"lesil ' style='font-size:20px;' ></i></a>"" +
                                                        ""<a href='/Admin/AdminProduct/ProductEdit?Id="" + row.Id + ""'><i class='fa fa-edit datatableduzenle' style='font-size:20px;'></i></a>"";
                                                }, ""orderable"": false
                                            },

                                        ],
                                        ""language"": {
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
                             ");
            WriteLiteral(@"   var productid = $(""#Id"").val();

                                $('#ProductList tbody').on('click', '.ProductListDelete', function () {
                                    var combinationid = $(this).attr('Id');

                                    $.ajax({
                                        type: 'GET',
                                        dataType: 'json',
                                        data: 'ProductId=' + productid,
                                        url: '/Admin/AdminProduct/ProductDelete',
                                        success: function (datas) {
                                            toastr.success(""Basariyla Silindi"");
                                            BindProductList();
                                        },
                                        error: function () {
                                            toastr.warning(""Veri Silerken hata"");
                                        },
                                    });");
            WriteLiteral(@"


                                });


                            });
                            $(""#ProductListForm"").submit(function (event) {
                                event.preventDefault();
                                $('#ProductList').DataTable().destroy();
                                BindProductList();
                            });

                        </script>



                    </div>


                </div>
            </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.ViewModels.AdminViewModel.AdminProduct.ProductListVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
