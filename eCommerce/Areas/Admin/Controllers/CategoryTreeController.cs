﻿using AutoMapper;
using Business.Services.CategoriesAggregate.Categories;
using Business.Services.CategoriesAggregate.Categories.CategoryServiceModel;
using Business.Services.CategoriesAggregate.CategorySpefications;
using Business.Services.CategoriesAggregate.CategorySpefications.CategorySpeficationServiceModel;
using Business.Services.SpeficationAggregate.SpecificationAttributes;
using Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels;
using Entities.Concrete.CategoriesAggregate;
using Entities.ViewModels.AdminViewModel.CategoryTree;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [AuthorizeControl("")]
    [Area("Admin")]
    public class CategoryTreeController : AdminBaseController
    {
        #region Fields
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly ICategorySpeficationService _categorySpeficationService;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryDAL _categoryDAL;
        private readonly IMapper _mapper;
        #endregion
        #region ctor
        public CategoryTreeController(ICategoryService categoryService, IMapper mapper,
            ISpecificationAttributeService specificationAttributeService,
            ICategorySpeficationService categorySpeficationService, ICategoryDAL categoryDAL)
        {
            this._categoryService = categoryService;
            this._mapper = mapper;
            this._specificationAttributeService = specificationAttributeService;
            this._categorySpeficationService = categorySpeficationService;
            _categoryDAL = categoryDAL;
        }
        #endregion
        #region Method
        public async Task<IActionResult> Index()
        {
            ViewBag.plist = (await _categoryService.GetAllCategories()).Data;
            return View();
        }
        public async Task<JsonResult> GetHierarchy()
        {
            var records = (await _categoryDAL.GetHierarchy()).Data;
            return Json(records, new JsonSerializerSettings());
        }
        [HttpPost]
        public async Task<JsonResult> ChangeNodePosition(int id, int? parentId)
        {
            if (parentId == 0)
                parentId = null;
            ResponseAlert(await _categoryService.ChangeNodePosition(new ChangeNodePosition(id, parentId)));
            return Json(true, new JsonSerializerSettings());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewNode(AddNode model)
        {
            if (model.NodeTypeRbtn == "Pn")
            {
                model.ParentName = null;
            }
            var categoryDetail = new Category()
            {
                CategoryName = model.NodeName,
                ParentCategoryId = model.ParentName,
            };
            ResponseAlert(await _categoryService.InsertCategory(categoryDetail));
            return Json(new { success = true });
        }
        [HttpPost]
        public async Task<JsonResult> DeleteNode(string values)
        {
            ResponseAlert(await _categoryService.DeleteNodes(new DeleteNodes(values)));
            Alert("İşlem Başarılı", NotificationType.success);
            return Json(new { success = true });
        }
        #endregion
        public async Task<IActionResult> CategoryEdit(int id)
        {
            return View(new CategoryEditVM
            {
                CategorySpeficationDTO = (await _categoryDAL.GetCategorySpefication(
                new GetCategorySpefication(id))).Data,
                SpeficationAttributeSelectList = (await _specificationAttributeService.GetProductSpeficationAttributeDropdwon(
                new GetProductSpeficationAttributeDropdwon())).Data
            });
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryEditVM model)
        {
            ResponseAlert(await _categoryService.UpdateCategory(model.CategorySpeficationDTO.Category));
            return RedirectToAction(nameof(CategoryEdit), new { id = model.CategorySpeficationDTO.Category.Id });
        }
        public async Task<IActionResult> CategoryFilterDelete(int speficationId, int categoryId)
        {
            var deletedData = await _categorySpeficationService.GetByCategorySpeficationId(new GetByCategorySpeficationId(speficationId, categoryId));
            ResponseAlert(await _categorySpeficationService.DeleteCategorySpefication(deletedData.Data));
            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = deletedData.Data.CategoryId });
        }
        [HttpPost]
        public async Task<IActionResult> CategoryFilterCreate(CategoryEditVM model)
        {
            ResponseAlert(await _categorySpeficationService.InsertCategorySpefication(model.CategorySpefication));
            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = model.Id });
        }
    }
}