using AutoMapper;
using Business.Services.BrandAggregate.Brands;
using Business.Services.BrandAggregate.Brands.BrandServiceModel;
using Business.Services.CategoriesAggregate.Categories;
using Business.Services.CategoriesAggregate.Categories.CategoryServiceModel;
using Business.Services.ShowcaseAggregate.ShowCaseProducts;
using Business.Services.ShowcaseAggregate.ShowCaseProducts.ShowCaseProductServiceModel;
using Business.Services.ShowcaseAggregate.ShowcaseServices;
using Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel;
using Business.Services.ShowcaseAggregate.ShowcaseTypes;
using Business.Services.ShowcaseAggregate.ShowcaseTypes.ShowcaseTypeServiceModel;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices.ShowcaseDALModels;
using Entities.Concrete.ShowcaseAggregate;
using Entities.DTO.ShowCase;
using Entities.ViewModels.AdminViewModel.Showcase;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class ShowcaseController : AdminBaseController
    {
        #region field
        private readonly IShowcaseService _showcaseService;
        private readonly ICategoryService _categoryService;
        private readonly IShowCaseProductService _showCaseProductService;
        private readonly IMapper _mapper;
        private readonly IShowcaseTypeService _showcaseTypeService;
        private readonly IShowcaseDAL _showcaseDal;
        private readonly IBrandService _brandService;
        #endregion
        #region constructer
        public ShowcaseController(IShowcaseService showcaseService, IMapper mapper
            , ICategoryService categoryService,IShowCaseProductService showCaseProductService,
            IShowcaseTypeService showcaseTypeService, IShowcaseDAL showcaseDal, IBrandService brandService)
        {
            this._showcaseService = showcaseService;
            this._mapper = mapper;
            this._categoryService = categoryService;
            this._showCaseProductService = showCaseProductService;
            _showcaseTypeService = showcaseTypeService;
            _showcaseDal = showcaseDal;
            _brandService = brandService;
        }
        #endregion
        #region Const
        public static Dictionary<int, string> ShowCaseDictionary = new Dictionary<int, string>
        {
            { 1, "tap1" },
            { 2, "tap2" },
            { 3, "tap3" },
            { 4, "tap4" },
        };
        #endregion
        #region Method
        public async Task<IActionResult> ShowcaseList()
        {
            var showCaseTask = (await _showcaseService.GetAllShowcase()).Data;
            return View(showCaseTask);
        }
        public async Task<IActionResult> ShowcaseCreate()
        {
            var model = new ShowCaseCreateOrUpdateVM();
            model.ShowCaseTypeList = (await _showcaseTypeService.GetAllShowCaseTypeSelectListItem(new GetAllShowCaseTypeSelectListItem(model.ShowCaseType))).Data;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ShowcaseCreate(ShowCaseCreateOrUpdateVM model)
        {
            var showcase = _mapper.Map<ShowCaseCreateOrUpdateVM, ShowCase>(model);
            ResponseAlert(await _showcaseService.InsertShowcase(showcase));
            return RedirectToAction("ShowcaseEdit", new { id = showcase.Id });
        }
        public async Task<IActionResult> ShowCaseDelete(int id)
        {
            ResponseAlert(await _showcaseService.DeleteShowCase(new DeleteShowCase(id)));
            return Json(true, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ShowcaseEdit(int id, string tap = null)
        {
            var model = new ShowCaseCreateOrUpdateVM();
            model.Tap = tap;
            var BrandSelectListItemsTask = _brandService.GetBrandDropdown(new GetBrandDropdown());
            var CategorySelectListItemsTask = _categoryService.GetCategoryDropdown(new GetCategoryDropdown());
            model.ShowCaseDto = (await _showcaseDal.GetShowCaseDto(new GetShowCaseDto(id))).Data;
            var ShowCaseTypeListTask = _showcaseTypeService.GetAllShowCaseTypeSelectListItem(new GetAllShowCaseTypeSelectListItem(model.ShowCaseDto.ShowCaseType));
            await Task.WhenAll(BrandSelectListItemsTask, CategorySelectListItemsTask, ShowCaseTypeListTask).ContinueWith((t) =>
            {
                model.BrandSelectListItems = BrandSelectListItemsTask.Result.Data;
                model.CategorySelectListItems = CategorySelectListItemsTask.Result.Data;
                model.ShowCaseTypeList = ShowCaseTypeListTask.Result.Data;
            });
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ShowcaseEdit(ShowCaseCreateOrUpdateVM model)
        {
            var showCaseMap = _mapper.Map<ShowCaseDTO, ShowCase>(model.ShowCaseDto);
            var brandSelectListItemsTask = _brandService.GetBrandDropdown(new GetBrandDropdown());
            var categorySelectListItemsTask = _categoryService.GetCategoryDropdown(new GetCategoryDropdown());
            model.ShowCaseDto = (await _showcaseDal.GetShowCaseDto(new GetShowCaseDto(model.ShowCaseDto.Id))).Data;
            var showCaseTypeListTask = _showcaseTypeService.GetAllShowCaseTypeSelectListItem(new GetAllShowCaseTypeSelectListItem(model.ShowCaseDto.ShowCaseType));
            await Task.WhenAll(brandSelectListItemsTask, categorySelectListItemsTask, showCaseTypeListTask).ContinueWith((t) =>
            {
                model.BrandSelectListItems = brandSelectListItemsTask.Result.Data;
                model.CategorySelectListItems = categorySelectListItemsTask.Result.Data;
                model.ShowCaseTypeList = showCaseTypeListTask.Result.Data;
            });
            ResponseAlert(await _showcaseService.UpdateShowcase(showCaseMap));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new{ id = model.Id,});
        }
        public async Task<IActionResult> ShowcaseAdded(ShowCaseProduct showCaseProduct)
        {
            ResponseAlert(await _showCaseProductService.InsertProductShowcase(showCaseProduct));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new
            {
                id = showCaseProduct.ShowCaseId,
                tap = ShowCaseDictionary[(int)ShowcaseTapList.ShowCaseAddedProductList]
            });
        }
        public async Task<IActionResult> ShowcaseDeletedproduct(int id, int showCaseId)
        {
            ResponseAlert(await _showCaseProductService.DeleteShowCaseProduct(new DeleteShowCaseProduct(id)));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new
            {
                id = showCaseId,
                tap = ShowCaseDictionary[(int)ShowcaseTapList.ShowCaseAddedProductList]
            });
        }
        #endregion
    }
}
