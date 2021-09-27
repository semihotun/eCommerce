using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Abstract.Categories;
using Business.Abstract.Spefications;
using Entities.ViewModels.Admin;
using eCommerce.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DataAccess.Abstract;
using eCommerce.Models;

namespace eCommerce.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Kontrol("")]
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
            var categoryTask = await _categoryService.GetAllCategories();
            var category = categoryTask.Data;
            var result = _mapper.Map<IList<Category>, IList<CategoryModel>>(category);
            ViewBag.plist = result;
            return View();
        }

        public async Task<JsonResult> GetHierarchy()
        {
            var records=await _categoryDAL.GetHierarchy();
            return Json(records.Data, new JsonSerializerSettings());
        }

        [HttpPost]
        public async Task<JsonResult> ChangeNodePosition(int id, int? parentId)
        {
            if (parentId == 0)
                parentId = null;

            ResponseAlert(await _categoryService.ChangeNodePosition(id, parentId));
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
            Category categoryDetail = new Category()
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
            ResponseAlert(await _categoryService.DeleteNodes(values));
            Alert("İşlem Başarılı", NotificationType.success);
            return Json(new { success = true });
        }
        #endregion

        public async Task<IActionResult> CategoryEdit(int id)
        {
            var model = new CategorySpeficationModel();
            model.CategorySpeficationDTO = (await _categoryDAL.GetCategorySpefication(id)).Data;
            model.SpeficationAttributeSelectList = (await _specificationAttributeService.GetProductSpeficationAttributeDropdwon()).Data;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategorySpeficationModel model)
        {
            ResponseAlert(await _categoryService.UpdateCategory(model.CategorySpeficationDTO.Category));

            return RedirectToAction(nameof(CategoryEdit),new { id= model.CategorySpeficationDTO.Category.Id});
        }
        public async Task<IActionResult> CategoryFilterDelete(int speficationId,int categoryId)
        {
            var deletedData = await _categorySpeficationService.GetByCategorySpeficationId(speficationId,categoryId);
            ResponseAlert(await _categorySpeficationService.DeleteCategorySpefication(deletedData.Data));

            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = deletedData.Data.CategoryId });
        }

        [HttpPost]
        public async Task<IActionResult> CategoryFilterCreate(CategorySpeficationModel model)
        {
            ResponseAlert(await _categorySpeficationService.InsertCategorySpefication(model.CategorySpefication));

            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = model.Id });
        }





    }
}