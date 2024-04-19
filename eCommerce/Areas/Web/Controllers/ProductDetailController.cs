using Business.Services.ProductAggregate.Products.DtoQueries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Controllers
{
    public class ProductDetailController : WebBaseController
    {
        #region Fields

        private readonly IProductDtoQuery _productDtoQuery;
        #endregion
        #region Constructors
        public ProductDetailController(IProductDtoQuery productDtoQuery)
        {
            _productDtoQuery = productDtoQuery;
        }
        #endregion
        public async Task<IActionResult> ProductDetail(Guid productId, Guid combinationId)
        {
            var model = (await _productDtoQuery.GetProductDetailVM(new(productId, combinationId))).Data;
            return View(model);
        }
        public async Task<IActionResult> GetAnotherProduct()
        {
            var data = (await _productDtoQuery.GetAnotherProductList()).Data;
            return Json(data, new JsonSerializerSettings());
        }
    }
}
