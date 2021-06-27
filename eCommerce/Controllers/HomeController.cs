using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Entities.ViewModels.Web;
using Entities.ViewModels.Web.Search;
using Entities.ViewModels.Web.SpecifationAttr;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using X.PagedList;
using System.Reflection;
using Entities.ViewModels.All;
using Business.Abstract.Products;
using Business.Abstract.Categories;
using Business.Abstract.Sliders;
using Business.Abstract.Showcases;
using Business.Abstract.Comments;
using Business.Abstract.Spefications;
using DataAccess.Abstract;
using eCommerce.Helpers;
using Entities.Helpers.AutoMapper;
using System.Diagnostics;
using Entities.DTO.Product;
using Iyzipay.Model;
using Iyzipay.Request;
using Core.Library;

namespace eCommerce.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        #region Fields
        private readonly IProductService _productService;
        private readonly IProductAttributeService _productattrService;
        private readonly ICategoryService _categoryService;
        private readonly ISliderService _sliderService;
        private readonly IShowcaseService _showcaseService;
        private readonly ICommentService _commentservice;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;
        private readonly ICategorySpeficationService _categorySpeficationService;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IProductAttributeCombinationService _productAttributeCombinationService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductAttributeValueService _productAttributeValueService;
        private readonly IProductDAL _productDAL;
        private readonly IProductAttributeMappingDAL _productAttributeMappingDAL;
        private readonly IShowcaseDAL _showcaseDal;
        private readonly ICategoryDAL _categoryDAL;
        #endregion

        #region Constructors
        public HomeController(IProductService productService,
            IProductAttributeService productattrService,
            ICategoryService categoryService,
            ISliderService sliderService,
            IShowcaseService showcaseService, ICommentService commentservice,
             IProductAttributeFormatter productAttributeFormatter,
             IMapper mapper, IHttpContextAccessor httpContextAccessor,
                UserManager<MyUser> userManager,
            SignInManager<MyUser> signInManager,
            ICategorySpeficationService categorySpeficationService,
            ISpecificationAttributeService specificationAttributeService,
            IProductAttributeCombinationService productAttributeCombinationService,
            IProductAttributeMappingService productAttributeMappingService,
            IProductAttributeValueService productAttributeValueService,
            IProductDAL _productDAL,
            IProductAttributeMappingDAL productAttributeMappingDAL, IShowcaseDAL showcaseDal, ICategoryDAL categoryDAL)
        {
            this._productService = productService;
            this._productattrService = productattrService;
            this._categoryService = categoryService;
            this._sliderService = sliderService;
            this._showcaseService = showcaseService;
            this._commentservice = commentservice;
            this._productAttributeFormatter = productAttributeFormatter;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            this._categorySpeficationService = categorySpeficationService;
            this._specificationAttributeService = specificationAttributeService;
            this._productAttributeCombinationService = productAttributeCombinationService;
            this._productAttributeMappingService = productAttributeMappingService;
            this._productAttributeValueService = productAttributeValueService;
            this._productDAL = _productDAL;
            this._productAttributeMappingDAL = productAttributeMappingDAL;
            _showcaseDal = showcaseDal;
            _categoryDAL = categoryDAL;
        }
        #endregion

        #region Method


        #region Search
        public async Task<PartialViewResult> Search(string searchKey)
        {
            SearchModel viewModel = new SearchModel();
            var tasks = new Task[1];
            int i = 0;
            viewModel = new SearchModel();
            viewModel.SearchKey = searchKey;
            List<Task> TaskList = GetSeachResult(searchKey, viewModel);
            foreach (Task tsk in TaskList)
            {
                tasks[i] = tsk;
                i++;
            }
            await Task.WhenAll(tasks);

            return PartialView("ResultView", viewModel);
        }

        private List<Task> GetSeachResult(string search, SearchModel model)
        {
            List<Task> Tasks = new List<Task>();
            var taskCustomer = Task.Factory.StartNew(async () =>
            {
                var dataTask = await _productService.MainSearchProduct(searchProductName: search, pageSize: 6);
                model.ProductList = dataTask.Data.ToList();
            });
            Tasks.Add(taskCustomer);
            return Tasks;
        }

        #endregion

        #region Catalog 

        public IActionResult Catalog(int id, int pageSize, int pageNumber = 1)
        {
            Catalog model = new Catalog();
            ViewBag.Sortingenum = SelectListHelper.FillSorting;
            model.CategoryId = id;
            model.pageNumber = pageNumber;
            model.pageSize = pageSize;
            return View(model);
        }

        public async Task<IActionResult> GetAllCategoryFilter(int categoryId)
        {
            var data = (await _categoryDAL.GetCategorySpeficationOptionDTO(categoryId)).Data;

            return Json(data, new JsonSerializerSettings());
        }

        public async Task<IActionResult> GetCatalogProduct(Catalog model)
        {
            model.Productlist = (await _productDAL.GetCatalogProduct(model)).Data;
            model.ProductCount = (int)Math.Ceiling((decimal)model.Productlist.TotalItemCount / (decimal)model.pageSize);

            return Json(model, new JsonSerializerSettings());
        }

        public async Task<IActionResult> GetCatalogBrand(int categoryId)
        {

            var brandList = await _productService.GetAllBrand();

            return Json(brandList, new JsonSerializerSettings());
        }


        #endregion
        public async Task<IActionResult> Index()
        {
         
 
            MainPageModel model = new MainPageModel();
            model.SliderList = (await _sliderService.GetAllSlider()).Data;
            model.ShowCaseList = (await _showcaseDal.GetAllShowCaseDto()).Data;
            return View(model);
        }


        #region ProductDetail
        public async Task<IActionResult> ProductDetail(int productId, int combinationId)
        {
            var model = new ProductDetailModel();
            model.ProductInfo = (await _productDAL.GetHomeProductDetail(productId, combinationId)).Data;
            model.CombinationId = combinationId;
            model.ProductId = productId;

            if (model.ProductInfo.ProductAttributeCombinationList.Count() > 0)
            {
                var combinationList = _productAttributeFormatter.ListAttrXmltoString(
                        model.ProductInfo.ProductAttributeCombinationList,
                         model.ProductInfo.ProductAttributeMappingList);
                model.AttrCombinationList = combinationList;

                if (combinationId == 0)
                    model.SelectedCombination = combinationList.First();
                else
                    model.SelectedCombination = combinationList.Where(x => x.Id == combinationId).First();

                var enabledList = new List<int>();
                if (combinationList.Select(x => x.AttributesXmlList).First().Count() > 1)//Kombinasyonu 1den fazla olan ürün
                {
                    foreach (var checkedid in model.SelectedCombination.AttributesXmlList.Select(x => x.AttributeId))
                    {
                        var searchList = combinationList.Where(x => x.AttributesXmlList.Any(x => x.AttributeId == checkedid)).ToList();
                        foreach (var combination in searchList.Where(x => x.ProductStockModel?.ProductStockPiece > 0))
                        {
                            foreach (var attr in combination.AttributesXmlList.Where(x => x.AttributeId != checkedid))
                            {
                                enabledList.Add(attr.AttributeId);
                            }
                        }
                    }
                }
                else if (combinationList.Select(x => x.AttributesXmlList).First().Count() == 1)  //Kombinasyonu 1 olan ürün
                {
                    foreach (var item in combinationList.Where(x =>x.ProductStockModel != null && x.ProductStockModel.ProductStockPiece > 0).Select(x => x.AttributesXmlList.Select(y => y.AttributeId)))
                    {
                        enabledList.AddRange(item);
                    }
                }
                model.EnabledList = enabledList;
            }

            return View(model);
        }

        public async Task<IActionResult> GetAnotherProduct()
        {
            var data =(await _productDAL.GetAnotherProductList()).Data;
            return Json(data,new JsonSerializerSettings());
        }

        [HttpPost]
        public IActionResult CommentAdded(ProductDetailModel entitiy, string Rating = "")
        {
            var user = _userManager.GetUserAsync(User);

            var model = entitiy.CommentModel;
            model.IsApproved = false;
            model.CreatedOnUtc = DateTime.Now;
            model.UserId = user.Result.Id;

            if (Rating != null)
                model.Rating = int.Parse(Rating);

            _commentservice.CommentAdd(model);
            return RedirectToAction("ProductDetail", "Home", new { productId = model.Productid, combinationId = entitiy.CombinationId });
        }

        #endregion


        [HttpGet]
        public async Task<IActionResult> AllCommentProduct(int id, int pageindex = 1, int pagesize = 10)
        {
            var model = new AllCommentModel();
            model.ProductCommentDTO = (await _productDAL.GetCommentList(x => x.Productid == id && x.IsApproved == false, id, pageindex, pagesize)).Data;
            model.Averagecount = Math.Round(model.ProductCommentDTO.CommentList.Select(x => x.Rating).ToList().Average(), 2);

            return View(model);
        }



        public IActionResult BasketAdded(Basket basket)
        {
            var basketJson = new List<Basket>();
            var basketCookie = Request.Cookies["Basket"];
            if (basketCookie != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>(basketCookie);
                Response.Cookies.Delete("Basket");
            }
            var includeProduct = basketJson.Where(x => x.ProductId == basket.ProductId && x.CombinationId == x.CombinationId);
            if (includeProduct.Count() == 0)
            {
                basketJson.Add(basket);
                var cookieData = JsonConvert.SerializeObject(basketJson);
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
                Response.Cookies.Append("Basket", cookieData, cookieOptions);
            }
            else
            {
                includeProduct.First().ProductPiece = includeProduct.First().ProductPiece + 1;
                var cookieData = JsonConvert.SerializeObject(basketJson);
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
                Response.Cookies.Append("Basket", cookieData, cookieOptions);
            }
            return RedirectToAction("Index");
        }


        public IActionResult Basket()
        {
            var basketCookie = Request.Cookies["Basket"];
            var result = new List<Basket>();
            if (basketCookie != null)
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                result = JsonConvert.DeserializeObject<List<Basket>>(basketCookie, settings);
            }
            return Json(result, new JsonSerializerSettings());
        }

        #endregion

        public async Task<IActionResult> Checkout()
        {
            var result = new Checkout();
            var basketCookie = Request.Cookies["Basket"];
            if (basketCookie != null)
            {
                var basketJson = JsonConvert.DeserializeObject<List<Basket>>(basketCookie);
                result = (await _productDAL.GetCheckout(basketJson)).Data;
            }
            return View(result);
        }







    }
}