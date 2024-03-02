using Business.Services.BasketAggregate.Baskets;
using Business.Services.ProductAggregate.Products;
using Business.Services.SliderAggregate.Sliders;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using Entities.Concrete.BasketAggregate;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class HomeController : BaseController
    {
        #region Fields
        private readonly IProductService _productService;
        private readonly ISliderService _sliderService;
        private readonly IProductDAL _productDAL;
        private readonly IShowcaseDAL _showcaseDal;
        private readonly IBasketService _basketService;
        #endregion
        #region Constructors
        public HomeController(
            IProductService productService,
            ISliderService sliderService,
            IProductDAL productDAL,
            IShowcaseDAL showcaseDal,
            IBasketService basketService)
        {
            _productService = productService;
            _sliderService = sliderService;
            _productDAL = productDAL;
            _showcaseDal = showcaseDal;
            _basketService = basketService;
        }
        #endregion
        #region Method
        public async Task<PartialViewResult> Search(string searchKey)
        {
            var productList = _productDAL.GetMainSearchProduct(new GetMainSearchProduct(searchProductName: searchKey, pageSize: 6));
            await Task.WhenAll(productList);
            var viewModel = new SearchVM
            {
                SearchKey = searchKey,
                ProductList = productList.Result.Data
            };
            return PartialView("ResultView", viewModel);
        }
        public async Task<IActionResult> Index()
        {
            var model = new MainPageVM();
            var sliderListTask = _sliderService.GetAllSlider();
            var showCaseListTask = _showcaseDal.GetAllShowCaseDto();
            await Task.WhenAll(sliderListTask, showCaseListTask).ContinueWith((t) =>
            {
                model.SliderList = sliderListTask.Result.Data;
                model.ShowCaseList = showCaseListTask.Result.Data;
            });
            return View(model);
        }
        public async Task<IActionResult> BasketAdded(Basket basket)
        {
            var result = await _basketService.AddBasket(basket);
            return Json(result);
        }
        public async Task<IActionResult> Basket()
        {
            var result = (await _basketService.GetBasket()).Data;
            return Json(result);
        }
        public async Task<IActionResult> Checkout() => View();
        public async Task<IActionResult> GetCheckout()
        {
            var basket = (await _basketService.GetBasket()).Data;
            var result = (await _productDAL.GetCheckout(new GetCheckout(basket))).Data;
            return Json(result, new JsonSerializerSettings());
        }
        public async Task<IActionResult> DeleteProductCheckout(Basket basket)
        {
            await _basketService.DeleteBasketProduct(basket);
            var basketData = (await _basketService.GetBasket()).Data;
            var result = (await _productDAL.GetCheckout(new GetCheckout(basketData))).Data;
            return Json(result, new JsonSerializerSettings());
        }
        public async Task<IActionResult> UpdateProductPiece(Basket basket)
        {
            var result = await _basketService.UpdateBasketProductPiece(basket);
            return Json(result, new JsonSerializerSettings());
        }
        public async Task<IActionResult> LikeProduct()
        {
            return Json(null,new JsonSerializerSettings());
        }
        #endregion
    }
}