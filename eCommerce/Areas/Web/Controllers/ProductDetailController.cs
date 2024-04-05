using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Controllers
{
    public class ProductDetailController : WebBaseController
    {
        #region Fields

        private readonly IProductDAL _productDAL;
        #endregion
        #region Constructors
        public ProductDetailController(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        #endregion
        public async Task<IActionResult> ProductDetail(int productId, int combinationId)
        {
            var model = (await _productDAL.GetProductDetailVM(new(productId, combinationId))).Data;
            return View(model);
        }
        public async Task<IActionResult> GetAnotherProduct()
        {
            var data = (await _productDAL.GetAnotherProductList()).Data;
            return Json(data, new JsonSerializerSettings());
        }
    }
}
