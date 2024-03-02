using AutoMapper;
using Business.Services.CommentsAggregate.Comments;
using Core.Library;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Controllers
{
    public class ProductDetailController : Controller
    {
        #region Fields
        private readonly UserManager<MyUser> _userManager;
        private readonly ICommentService _commentservice;
        private readonly IProductDAL _productDAL;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public ProductDetailController(UserManager<MyUser> userManager, ICommentService commentservice, IProductDAL productDAL, IMapper mapper)
        {
            _userManager = userManager;
            _commentservice = commentservice;
            _productDAL = productDAL;
            _mapper = mapper;
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
