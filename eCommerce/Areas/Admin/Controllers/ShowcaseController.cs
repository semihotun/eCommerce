using Business.Services.BrandAggregate.Brands.Queries;
using Business.Services.CategoriesAggregate.Categories.Queries;
using Business.Services.ShowcaseAggregate.ShowCaseProducts.Commands;
using Business.Services.ShowcaseAggregate.ShowcaseServices.Commands;
using Business.Services.ShowcaseAggregate.ShowcaseServices.DtoQueries;
using Business.Services.ShowcaseAggregate.ShowcaseServices.Queries;
using Business.Services.ShowcaseAggregate.ShowcaseTypes.Queries;
using Entities.Concrete;
using Entities.Dtos.ShowcaseDALModels;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
using Entities.ViewModels.AdminViewModel.Showcase;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class ShowcaseController : AdminBaseController
    {
        #region ctor
        private readonly IShowCaseQueryService _showCaseQueryService;
        private readonly IShowCaseCommandService _showCaseCommandService;
        private readonly IShowcaseTypeQueryService _showcaseTypeQueryService;
        private readonly IBrandQueryService _brandQueryService;
        private readonly ICategoryQueryService _categoryQueryService;
        private readonly IShowCaseDtoQueryService _showCaseDtoQueryService;
        private readonly IShowcaseProductCommandService _showCaseProductService;
        public ShowcaseController(IShowCaseQueryService showCaseQueryService,
            IShowCaseCommandService showCaseCommandService,
            IShowcaseTypeQueryService showcaseTypeQueryService,
            IBrandQueryService brandQueryService,
            ICategoryQueryService categoryQueryService,
            IShowCaseDtoQueryService showCaseDtoQueryService,
            IShowcaseProductCommandService showCaseProductService)
        {
            _showCaseQueryService = showCaseQueryService;
            _showCaseCommandService = showCaseCommandService;
            _showcaseTypeQueryService = showcaseTypeQueryService;
            _brandQueryService = brandQueryService;
            _categoryQueryService = categoryQueryService;
            _showCaseDtoQueryService = showCaseDtoQueryService;
            _showCaseProductService = showCaseProductService;
        }
        #endregion
        #region Method
        public async Task<IActionResult> ShowcaseList()
        {
            return View((await _showCaseQueryService.GetAllShowcase()).Data);
        }
        public async Task<IActionResult> ShowcaseCreate() => View(new ShowCaseCreateOrUpdateVM
        {
            ShowCaseTypeList = (await _showcaseTypeQueryService.GetAllShowCaseTypeSelectListItem(new())).Data
        });
        [HttpPost]
        public async Task<IActionResult> ShowcaseCreate(ShowCaseCreateOrUpdateVM model)
        {
            var showcase = model.MapTo<InsertShowcaseReqModel>();
            var id = ResponseAlert(await _showCaseCommandService.InsertShowcase(showcase))?.Data?.Id;
            return RedirectToAction("ShowcaseEdit", new { id = id });
        }
        public async Task<IActionResult> ShowCaseDelete(Guid id)
        {
            ResponseAlert(await _showCaseCommandService.DeleteShowCase(new(id)));
            return Json(true, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ShowcaseEdit(Guid id, string? tap)
        {
            var brandTask = _brandQueryService.GetBrandDropdown(new());
            var categoryTask = _categoryQueryService.GetCategoryDropdown(new());
            var showcaseTypeTask = _showcaseTypeQueryService.GetAllShowCaseTypeSelectListItem(new(id));
            var showcaseTask = _showCaseDtoQueryService.GetShowCaseDto(new(id));
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
            var showcaseTask = _showCaseDtoQueryService.GetShowCaseDto(new GetShowCaseDto(model.ShowCaseDto.Id));
            var brandTask = _brandQueryService.GetBrandDropdown(new());
            var categoryTask = _categoryQueryService.GetCategoryDropdown(new());
            var showcaseTypeTask = _showcaseTypeQueryService.GetAllShowCaseTypeSelectListItem(new(model.ShowCaseDto.ShowCaseType));
            await Task.WhenAll(showcaseTask, brandTask, categoryTask, showcaseTypeTask);
            model.ShowCaseDto = (await showcaseTask).Data;
            model.BrandSelectListItems = (await brandTask).Data;
            model.CategorySelectListItems = (await categoryTask).Data;
            model.ShowCaseTypeList = (await showcaseTypeTask).Data;
            ResponseAlert(await _showCaseCommandService.UpdateShowcase(showCaseMap));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new { id = model.Id });
        }
        public async Task<IActionResult> ShowcaseAdded(ShowCaseProduct showCaseProduct)
        {
            var data = showCaseProduct.MapTo<InsertProductShowcaseReqModel>();
            ResponseAlert(await _showCaseProductService.InsertProductShowcase(data));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new
            {
                id = showCaseProduct.ShowCaseId,
                tap = ShowCaseTap.ShowCaseDictionary[(int)ShowcaseTapList.ShowCaseAddedProductList]
            });
        }
        public async Task<IActionResult> ShowcaseDeletedproduct(Guid id, Guid showCaseId)
        {
            ResponseAlert(await _showCaseProductService.DeleteShowCaseProduct(new(id)));
            return RedirectToAction("ShowcaseEdit", "ShowCase", new
            {
                id = showCaseId,
                tap = ShowCaseTap.ShowCaseDictionary[(int)ShowcaseTapList.ShowCaseAddedProductList]
            });
        }
        #endregion
    }
}
