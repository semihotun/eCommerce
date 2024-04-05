using Business.Services.BrandAggregate.Brands;
using Business.Services.CategoriesAggregate.Categories;
using Business.Services.ShowcaseAggregate.ShowCaseProducts;
using Business.Services.ShowcaseAggregate.ShowcaseServices;
using Business.Services.ShowcaseAggregate.ShowcaseTypes;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using Entities.Concrete.ShowcaseAggregate;
using Entities.Dtos.ShowcaseDALModels;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
using Entities.ViewModels.AdminViewModel.Showcase;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class ShowcaseController : AdminBaseController
    {
        #region field
        private readonly IShowcaseService _showcaseService;
        private readonly ICategoryService _categoryService;
        private readonly IShowCaseProductService _showCaseProductService;
        private readonly IShowcaseTypeService _showcaseTypeService;
        private readonly IShowcaseDAL _showcaseDal;
        private readonly IBrandService _brandService;
        private readonly Dictionary<int, string> ShowCaseDictionary = ShowCaseTap.ShowCaseDictionary;
        #endregion
        #region constructer
        public ShowcaseController(IShowcaseService showcaseService, ICategoryService categoryService, IShowCaseProductService showCaseProductService,
            IShowcaseTypeService showcaseTypeService, IShowcaseDAL showcaseDal, IBrandService brandService)
        {
            this._showcaseService = showcaseService;
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
            return View((await _showcaseService.GetAllShowcase()).Data);
        }
        public async Task<IActionResult> ShowcaseCreate() => View(new ShowCaseCreateOrUpdateVM
        {
            ShowCaseTypeList = (await _showcaseTypeService.GetAllShowCaseTypeSelectListItem(new ())).Data
        });
        [HttpPost]
        public async Task<IActionResult> ShowcaseCreate(ShowCaseCreateOrUpdateVM model)
        {
            var showcase =model.MapTo<InsertShowcaseReqModel>();
            var id = ResponseAlert(await _showcaseService.InsertShowcase(showcase))?.Data?.Id;
            return RedirectToAction("ShowcaseEdit", new { id = id });
        }
        public async Task<IActionResult> ShowCaseDelete(int id)
        {
            ResponseAlert(await _showcaseService.DeleteShowCase(new (id)));
            return Json(true, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ShowcaseEdit(int id, string? tap)
        {
            var brandTask = _brandService.GetBrandDropdown(new ());
            var categoryTask = _categoryService.GetCategoryDropdown(new ());
            var showcaseTypeTask = _showcaseTypeService.GetAllShowCaseTypeSelectListItem(new (id));
            var showcaseTask = _showcaseDal.GetShowCaseDto(new (id));
            await Task.WhenAll(brandTask, categoryTask, showcaseTypeTask);
            return View(new ShowCaseCreateOrUpdateVM
            {
                Tap = tap,
                BrandSelectListItems = (await brandTask).Data,
                CategorySelectListItems = (await categoryTask).Data,
                ShowCaseTypeList = (await showcaseTypeTask).Data,
                ShowCaseDto = (await showcaseTask).Data
        });
        }
        [HttpPost]
        public async Task<IActionResult> ShowcaseEdit(ShowCaseCreateOrUpdateVM model)
        {
            var showCaseMap = model.ShowCaseDto.MapTo<UpdateShowcaseReqModel>();
            var showcaseTask = _showcaseDal.GetShowCaseDto(new GetShowCaseDto(model.ShowCaseDto.Id));
            var brandTask = _brandService.GetBrandDropdown(new ());
            var categoryTask = _categoryService.GetCategoryDropdown(new ());
            var showcaseTypeTask = _showcaseTypeService.GetAllShowCaseTypeSelectListItem(new (model.ShowCaseDto.ShowCaseType));
            await Task.WhenAll(showcaseTask, brandTask, categoryTask, showcaseTypeTask);
            model.ShowCaseDto = (await showcaseTask).Data;
            model.BrandSelectListItems = (await brandTask).Data;
            model.CategorySelectListItems = (await categoryTask).Data;
            model.ShowCaseTypeList = (await showcaseTypeTask).Data;
            ResponseAlert(await _showcaseService.UpdateShowcase(showCaseMap));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new { id = model.Id });
        }
        public async Task<IActionResult> ShowcaseAdded(ShowCaseProduct showCaseProduct)
        {
            var data = showCaseProduct.MapTo<InsertProductShowcaseReqModel>();
            ResponseAlert(await _showCaseProductService.InsertProductShowcase(data));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new
            {
                id = showCaseProduct.ShowCaseId,
                tap = ShowCaseDictionary[(int)ShowcaseTapList.ShowCaseAddedProductList]
            });
        }
        public async Task<IActionResult> ShowcaseDeletedproduct(int id, int showCaseId)
        {
            ResponseAlert(await _showCaseProductService.DeleteShowCaseProduct(new(id)));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new
            {
                id = showCaseId,
                tap = ShowCaseDictionary[(int)ShowcaseTapList.ShowCaseAddedProductList]
            });
        }
        #endregion
    }
}
