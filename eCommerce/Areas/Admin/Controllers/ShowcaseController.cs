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
        private readonly Dictionary<int, string> ShowCaseDictionary = ShowCaseTap.ShowCaseDictionary;
        #endregion
        #region constructer
        public ShowcaseController(IShowcaseService showcaseService, IMapper mapper
            , ICategoryService categoryService, IShowCaseProductService showCaseProductService,
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
        #region Method
        public async Task<IActionResult> ShowcaseList()
        {
            return View((await _showcaseService.GetAllShowcase()).Data);
        }
        public async Task<IActionResult> ShowcaseCreate() => View(new ShowCaseCreateOrUpdateVM
        {
            ShowCaseTypeList = (await _showcaseTypeService.GetAllShowCaseTypeSelectListItem(new GetAllShowCaseTypeSelectListItem(0))).Data
        });
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
        public async Task<IActionResult> ShowcaseEdit(int id, string? tap)
        {
            var model = new ShowCaseCreateOrUpdateVM
            {
                Tap = tap,
                BrandSelectListItems = (await _brandService.GetBrandDropdown(new GetBrandDropdown())).Data,
                CategorySelectListItems = (await _categoryService.GetCategoryDropdown(new GetCategoryDropdown())).Data,
            };
            model.ShowCaseTypeList = (await _showcaseTypeService.GetAllShowCaseTypeSelectListItem(new GetAllShowCaseTypeSelectListItem(model.ShowCaseDto.ShowCaseType))).Data;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ShowcaseEdit(ShowCaseCreateOrUpdateVM model)
        {
            var showCaseMap = _mapper.Map<ShowCaseDTO, ShowCase>(model.ShowCaseDto);
            model.ShowCaseDto = (await _showcaseDal.GetShowCaseDto(new GetShowCaseDto(model.ShowCaseDto.Id))).Data;
            model.BrandSelectListItems = (await _brandService.GetBrandDropdown(new GetBrandDropdown())).Data;
            model.CategorySelectListItems = (await _categoryService.GetCategoryDropdown(new GetCategoryDropdown())).Data;
            model.ShowCaseTypeList = (await _showcaseTypeService.GetAllShowCaseTypeSelectListItem(new GetAllShowCaseTypeSelectListItem(model.ShowCaseDto.ShowCaseType))).Data;
            ResponseAlert(await _showcaseService.UpdateShowcase(showCaseMap));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new { id = model.Id, });
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
