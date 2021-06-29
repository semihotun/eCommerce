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

namespace eCommerce.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]

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
            List<HierarchyViewModel> records;
            var hdList = await _categoryService.GetAllCategories();
            records = hdList.Data.Where(l => l.ParentCategoryId == null)
                .Select(l => new HierarchyViewModel
                {
                    Id = l.Id,
                    text = l.CategoryName,
                    perentId = l.ParentCategoryId,
                    children = GetChildren(hdList.Data, l.Id)
                }).ToList();

            return this.Json(records, new JsonSerializerSettings());
        }

        private List<HierarchyViewModel> GetChildren(IList<Category> hdList, int parentId)
        {
            return hdList.Where(l => l.ParentCategoryId == parentId)
                .Select(l => new HierarchyViewModel
                {
                    Id = l.Id,
                    text = l.CategoryName,
                    perentId = l.ParentCategoryId,
                    children = GetChildren(hdList, l.Id)
                }).ToList();
        }

        [HttpPost]
        public async Task<JsonResult> ChangeNodePosition(int id, int? parentId)
        {
            if (parentId == 0)
                parentId = null;

            var hdTask = await _categoryService.GetAllCategories();
            var hd = hdTask.Data.First(l => l.Id == id);
            hd.ParentCategoryId = parentId;
            var update=_categoryService.UpdateCategory(hd);

            Alert("İşlem Başarılı", NotificationType.success);

            return this.Json(true, new JsonSerializerSettings());
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

            await _categoryService.InsertCategory(categoryDetail);
            Alert("İşlem Başarılı", NotificationType.success);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult DeleteNode(string values)
        {
            var ids = values.Split(',');
            foreach (var item in ids)
            {
                _categoryService.RemoveRangeCategory(int.Parse(item));
            }
            Alert("İşlem Başarılı", NotificationType.success);
            return Json(new { success = true });
        }
        #endregion

        public async Task<IActionResult> CategoryEdit(int id)
        {
            var model = new CategorySpeficationModel();
            model.CategorySpeficationDTO = (await _categoryDAL.GetCategorySpefication(id)).Data;
            var category = await _categoryService.GetCategoryById(id);
            model.SpeficationAttributeSelectList = (await _specificationAttributeService.GetProductSpeficationAttributeDropdwon()).Data;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategorySpeficationModel model)
        {
            await _categoryService.UpdateCategory(model.CategorySpeficationDTO.Category);

            return RedirectToAction(nameof(CategoryEdit),new { id= model.CategorySpeficationDTO.Category.Id});
        }
        public async Task<IActionResult> CategoryFilterDelete(int speficationId,int categoryId)
        {
            var deletedData = await _categorySpeficationService.GetByCategorySpeficationId(speficationId,categoryId);
            await _categorySpeficationService.DeleteCategorySpefication(deletedData.Data);

            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = deletedData.Data.CategoryId });
        }

        [HttpPost]
        public async Task<IActionResult> CategoryFilterCreate(CategorySpeficationModel model)
        {
   
            await _categorySpeficationService.InsertCategorySpefication(model.CategorySpefication);

            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = model.Id });
        }





    }
}