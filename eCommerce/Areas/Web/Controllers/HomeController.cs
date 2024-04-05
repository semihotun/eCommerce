using Business.Services.BasketAggregate.Baskets;
using Business.Services.SliderAggregate.Sliders;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using Entities.Concrete.BasketAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.BasketAggregate.Baskets;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class HomeController : WebBaseController
    {
        #region Fields
        private readonly ISliderService _sliderService;
        private readonly IProductDAL _productDAL;
        private readonly IShowcaseDAL _showcaseDal;
        private readonly IBasketService _basketService;
        #endregion
        #region Constructors
        public HomeController(
            ISliderService sliderService,
            IProductDAL productDAL,
            IShowcaseDAL showcaseDal,
            IBasketService basketService)
        {
            _sliderService = sliderService;
            _productDAL = productDAL;
            _showcaseDal = showcaseDal;
            _basketService = basketService;
        }
        #endregion
        #region Method
        public async Task<PartialViewResult> Search(string searchKey)
        {
            var productList = await _productDAL.GetMainSearchProduct(new(pageSize: 6, searchProductName: searchKey));

            return PartialView("ResultView", new SearchVM
            {
                SearchKey = searchKey,
                ProductList = productList.Data
            });
        }
        public async Task<IActionResult> Index()
        {
            return View(new MainPageVM()
            {
                SliderList = (await _sliderService.GetAllSlider()).Data,
                ShowCaseList = (await _showcaseDal.GetAllShowCaseDto()).Data
            });
        }
        public async Task<IActionResult> BasketAdded(Basket basket)
        {
            var data = basket.MapTo<AddBasketReqModel>();
            var result = await _basketService.AddBasket(data);
            return Json(result);
        }
        public async Task<IActionResult> Basket()
        {
            var result = (await _basketService.GetBasket()).Data;
            return Json(result);
        }
        public IActionResult Checkout() => View();
        public async Task<IActionResult> GetCheckout()
        {
            var basket = (await _basketService.GetBasket()).Data;
            var result = (await _productDAL.GetCheckout(new(basket))).Data;
            return Json(result, new JsonSerializerSettings());
        }
        public async Task<IActionResult> DeleteProductCheckout(Basket basket)
        {
            var data = basket.MapTo<DeleteBasketProductReqModel>();
            await _basketService.DeleteBasketProduct(data);
            var basketData = (await _basketService.GetBasket()).Data;
            var result = (await _productDAL.GetCheckout(new(basketData))).Data;
            return Json(result, new JsonSerializerSettings());
        }
        public async Task<IActionResult> UpdateProductPiece(Basket basket)
        {
            var data = basket.MapTo<UpdateBasketProductPieceReqModel>();
            var result = await _basketService.UpdateBasketProductPiece(data);
            return Json(result, new JsonSerializerSettings());
        }
        public IActionResult LikeProduct()
        {
            return Json(null, new JsonSerializerSettings());
        }
        #endregion
    }
}