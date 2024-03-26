using AutoMapper;
using Business.Services.CommentsAggregate.Comments;
using Core.Library;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Controllers
{
    public class ProductDetailController : Controller
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
            var model = (await _productDAL.GetProductDetailVM(
                new GetProductDetailVM(productId, combinationId))).Data;
            return View(model);
        }
        public async Task<IActionResult> GetAnotherProduct()
        {
            var data = (await _productDAL.GetAnotherProductList()).Data;
            return Json(data, new JsonSerializerSettings());
        }
    }
}
