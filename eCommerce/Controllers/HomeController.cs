using AutoMapper;
using Business.Services.BasketAggregate.Baskets;
using Business.Services.ProductAggregate.Products;
using Business.Services.ProductAggregate.Products.ProductServiceModel;
using Business.Services.SliderAggregate.Sliders;
using Core.CrossCuttingConcerns.Caching;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using Entities.Concrete.BasketAggregate;
using Entities.DTO.Product;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class HomeController : Controller
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
            var viewModel = new SearchVM
            {
                SearchKey = searchKey
            };
            var productList = _productService.MainSearchProduct(new MainSearchProduct(searchProductName: searchKey, pageSize: 6));
            await Task.WhenAll(productList);
            viewModel.ProductList = productList.Result.Data;

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
            var result=await _basketService.BasketAdded(basket);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Basket()
        {
            var result = (await _basketService.GetBasket()).Data;

            return Json(result);
        }

        public async Task<IActionResult> Checkout()
        {
            var basket = (await _basketService.GetBasket()).Data;
            var result = (await _productDAL.GetCheckout(new GetCheckout(basket))).Data;
           
            return View(result);
        }
        #endregion








    }
}