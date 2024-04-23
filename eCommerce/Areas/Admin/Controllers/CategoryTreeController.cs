using Business.Services.CategoriesAggregate.Categories.Commands;
using Business.Services.CategoriesAggregate.Categories.DtoQueries;
using Business.Services.CategoriesAggregate.Categories.Queries;
using Business.Services.CategoriesAggregate.CategorySpefications.Commands;
using Business.Services.CategoriesAggregate.CategorySpefications.Queries;
using Business.Services.SpeficationAggregate.SpeficationAttributes.Queries;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CategoriesAggregate.Categories;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using Entities.ViewModels.AdminViewModel.CategoryTree;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class CategoryTreeController : AdminBaseController
    {
        #region ctor
        private readonly ICategoryQueryService _categoryQueryService;
        private readonly ICategoryDtoQueryService _categoryDtoQueryService;
        private readonly ICategoryCommandService _categoryCommandService;
        private readonly ICategorySpeficationQueryService _categorySpeficationQueryService;
        private readonly ICategorySpeficationCommandService _categorySpeficationCommandService;
        private readonly ISpecificationAttributeQueryService _specificationAttributeQueryService;

        public CategoryTreeController(ICategoryQueryService categoryQueryService,
            ICategoryDtoQueryService categoryDtoQueryService,
            ICategoryCommandService categoryCommandService,
            ICategorySpeficationQueryService categorySpeficationQueryService,
            ICategorySpeficationCommandService categorySpeficationCommandService,
            ISpecificationAttributeQueryService specificationAttributeQueryService)
        {
            _categoryQueryService = categoryQueryService;
            _categoryDtoQueryService = categoryDtoQueryService;
            _categoryCommandService = categoryCommandService;
            _categorySpeficationQueryService = categorySpeficationQueryService;
            _categorySpeficationCommandService = categorySpeficationCommandService;
            _specificationAttributeQueryService = specificationAttributeQueryService;
        }
        #endregion
        #region Method
        public async Task<IActionResult> Index()
        {
            ViewBag.plist = (await _categoryQueryService.GetAllCategories()).Data;
            return View();
        }
        #endregion
        public async Task<IActionResult> CategoryEdit(Guid id)
        {
            return View(new CategoryEditVM
            {
                CategorySpeficationDTO = (await _categoryDtoQueryService.GetCategorySpefication(new(id))).Data,
                SpeficationAttributeSelectList = (await _specificationAttributeQueryService.GetProductSpeficationAttributeDropdwon(
                new())).Data
            });
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryEditVM model)
        {
            var data = model.CategorySpeficationDTO.Category.MapTo<UpdateCategoryReqModel>();
            ResponseAlert(await _categoryCommandService.UpdateCategory(data));
            return RedirectToAction(nameof(CategoryEdit), new { id = model.CategorySpeficationDTO.Category.Id });
        }
        public async Task<IActionResult> CategoryFilterDelete(Guid speficationId, Guid categoryId)
        {
            var deletedData = await _categorySpeficationQueryService.GetByCategorySpeficationId(new(speficationId, categoryId));
            var data = deletedData.Data.MapTo<DeleteCategorySpeficationReqModel>();
            ResponseAlert(await _categorySpeficationCommandService.DeleteCategorySpefication(data));
            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = deletedData?.Data?.CategoryId });
        }
        [HttpPost]
        public async Task<IActionResult> CategoryFilterCreate(CategoryEditVM model)
        {
            var data = model.CategorySpefication.MapTo<InsertCategorySpeficationReqModel>();
            ResponseAlert(await _categorySpeficationCommandService.InsertCategorySpefication(data));
            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = model.Id });
        }
    }
}