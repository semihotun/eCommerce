#pragma checksum "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\StockPrice\_ProductStockPriceDataTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5269ea79f1b876468e92b3292bc982436629fc50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminProduct_StockPrice__ProductStockPriceDataTable), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminProduct/StockPrice/_ProductStockPriceDataTable.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5269ea79f1b876468e92b3292bc982436629fc50", @"/Areas/Admin/Views/AdminProduct/StockPrice/_ProductStockPriceDataTable.cshtml")]
    public class Areas_Admin_Views_AdminProduct_StockPrice__ProductStockPriceDataTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.ViewModels.Admin.ProductModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Semih\source\repos\eCommerce\eCommerce\Areas\Admin\Views\AdminProduct\StockPrice\_ProductStockPriceDataTable.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""table-responsive ps ps--active-x"">


<table id=""ProductStockPriceList"" class=""table tablesorter table-hover dt-responsive nowrapr"" width=""100%"" cellspacing=""0"">

    <thead>
    <tr>
        <th>Id</th>
        <th>Ürün Adı</th>
        <th>Stok Miktarı</th>
        <th></th>
    </tr>
    </thead>
    <tbody></tbody>
</table>
</div>

");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.ViewModels.Admin.ProductModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
