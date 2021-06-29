using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Abstract.Brands;
using Business.Abstract.Categories;
using Business.Abstract.Showcases;
using DataAccess.Abstract;
using Entities.ViewModels.Admin;
using eCommerce.Helpers;
using Entities.Concrete;
using Entities.DTO.ShowCase;
using Entities.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using X.PagedList;
using eCommerce.Models;

namespace eCommerce.Areas.Admin.Controllers
{
    [Kontrol("")]
    [Route("[area]/[controller]/[action]")]

    [Area("Admin")]
    public class ShowcaseController : AdminBaseController
    {
        #region field
        private readonly IShowcaseService _showcaseService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IShowCaseProductService _showCaseProductService;
        private readonly IMapper _mapper;
        private readonly IShowcaseTypeService _showcaseTypeService;
        private readonly IShowcaseDAL _showcaseDal;
        private readonly IBrandService _brandService;
        #endregion
        #region constructer
        public ShowcaseController(IShowcaseService showcaseService, IProductService productService, IMapper mapper
            , ICategoryService categoryService,
            IShowCaseProductService showCaseProductService, IShowcaseTypeService showcaseTypeService, IShowcaseDAL showcaseDal, IBrandService brandService)
        {
            this._showcaseService = showcaseService;
            this._productService = productService;
            this._mapper = mapper;
            this._categoryService = categoryService;
            this._showCaseProductService = showCaseProductService;
            _showcaseTypeService = showcaseTypeService;
            _showcaseDal = showcaseDal;
            _brandService = brandService;
        }
        #endregion
        #region Method
        public async Task<IActionResult> ShowcaseList()
        {
            var showCaseTask = await _showcaseService.GetAllShowcase();
            return View(showCaseTask.Data);
        }

        public async Task<IActionResult> ShowcaseCreate()
        {
            var model = new ShowCaseModel();
            model.ShowCaseTypeList = (await _showcaseTypeService.GetAllShowCaseTypeSelectListItem(model.ShowCaseType)).Data;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ShowcaseCreate(ShowCaseModel model)
        {
            try
            {
                var showcase = _mapper.Map<ShowCaseModel, ShowCase>(model);
                await _showcaseService.InsertShowcase(showcase);

                Alert("Kayıt Eklendi", NotificationType.success);
                return RedirectToAction("ShowcaseEdit", new { id = showcase.Id });
            }
            catch
            {
                model.ShowCaseTypeList = (await _showcaseTypeService.GetAllShowCaseTypeSelectListItem(model.ShowCaseType)).Data;
                Alert("Kayıt eklenemedi", NotificationType.error);
                return View();
            }

        }
        public IActionResult ShowCaseDelete(int id)
        {
            _showcaseService.DeleteShowCase(id);
            Alert("Kayıt Silindi", NotificationType.error);
            return Json(true, new JsonSerializerSettings());
        }

        public async Task<IActionResult> ShowcaseEdit(int id,string tap=null)
        {
            var model = new ShowCaseModel();
            var showCaseProduct = await _showcaseDal.GetShowCaseDto(id);
            model.ShowCaseDto = showCaseProduct.Data;
            model.Tap = tap;

            //Sabit List
            model.BrandSelectListItems = (await _brandService.GetBrandDropdown()).Data;
            model.CategorySelectListItems = (await _categoryService.GetCategoryDropdown()).Data;
            model.ShowCaseTypeList = (await _showcaseTypeService.GetAllShowCaseTypeSelectListItem(model.ShowCaseDto.ShowCaseType)).Data;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ShowcaseEdit(ShowCaseModel model)
        {
            //Update
            var showCaseMap = _mapper.Map<ShowCaseDTO, ShowCase>(model.ShowCaseDto);
            await _showcaseService.UpdateShowcase(showCaseMap);
            //Get
            var showCaseProduct = await _showcaseDal.GetShowCaseDto(model.ShowCaseDto.Id);
            model.ShowCaseDto = showCaseProduct.Data;
            //Sabit List
            model.ShowCaseTypeList = (await _showcaseTypeService.GetAllShowCaseTypeSelectListItem(model.ShowCaseDto.ShowCaseType)).Data;
            model.BrandSelectListItems = (await _brandService.GetBrandDropdown()).Data;
            model.CategorySelectListItems = (await _categoryService.GetCategoryDropdown()).Data;

            return View(model);
        }
        public async Task<IActionResult> ShowcaseAdded(ShowCaseProduct showCaseProduct)
        {
            await _showCaseProductService.InsertProductShowcase(showCaseProduct);

            return RedirectToAction("ShowcaseEdit", "ShowCase", new
            {
                id = showCaseProduct.ShowCaseId,
                tap = ShowCaseDictionary[(int)ShowcaseTapList.ShowCaseAddedProductList]
            });
        }

        public async Task<IActionResult> ShowcaseDeletedproduct(int id, int showCaseId)
        {
            await _showCaseProductService.DeleteShowCaseProduct(id: id);

            return RedirectToAction("ShowcaseEdit", "ShowCase", new
            {
                id = showCaseId,
                tap = ShowCaseDictionary[(int)ShowcaseTapList.ShowCaseAddedProductList]
            });

        }

        public enum ShowcaseTapList
        {
            ShowCaseInfo = 1,
            ShowCaseText = 2,
            ShowCaseProductList = 3,
            ShowCaseAddedProductList = 4
        }
        public static Dictionary<int, string> ShowCaseDictionary = new Dictionary<int, string>
        {
            { 1, "tap1" },
            { 2, "tap2" },
            { 3, "tap3" },
            { 4, "tap4" },
        };







        #endregion








    }

}









