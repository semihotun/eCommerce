using Business.Services.BasketAggregate.Baskets;
using Business.Services.ProductAggregate.Products.DtoQueries;
using Business.Services.ShowcaseAggregate.ShowcaseServices.DtoQueries;
using Business.Services.SliderAggregate.Sliders.Queries;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.BasketAggregate.Baskets;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Controllers
{
    public class HomeController : WebBaseController
    {
        #region Constructors
        private readonly ISliderQueryService _sliderQueryService;
        private readonly IShowCaseDtoQueryService _showCaseQueryService;
        private readonly IBasketService _basketService;
        private readonly IProductDtoQueryService _productDtoQuery;
        public HomeController(ISliderQueryService sliderQueryService,
            IShowCaseDtoQueryService showCaseQueryService,
            IBasketService basketService,
            IProductDtoQueryService productDtoQuery)
        {
            _sliderQueryService = sliderQueryService;
            _showCaseQueryService = showCaseQueryService;
            _basketService = basketService;
            _productDtoQuery = productDtoQuery;
        }
        #endregion
        #region Method
        public async Task<PartialViewResult> Search(string searchKey, CancellationToken cancellationToken)
        {
            var productList = await _productDtoQuery.GetMainSearchProduct(new(pageSize: 6, searchProductName: searchKey, cancellationToken));

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
                SliderList = (await _sliderQueryService.GetAllSlider()).Data,
                ShowCaseList = (await _showCaseQueryService.GetAllShowCaseDto()).Data
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
            var result = (await _productDtoQuery.GetCheckout(new(basket))).Data;
            return Json(result, new JsonSerializerSettings());
        }
        public async Task<IActionResult> DeleteProductCheckout(Basket basket)
        {
            var data = basket.MapTo<DeleteBasketProductReqModel>();
            await _basketService.DeleteBasketProduct(data);
            var basketData = (await _basketService.GetBasket()).Data;
            var result = (await _productDtoQuery.GetCheckout(new(basketData))).Data;
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