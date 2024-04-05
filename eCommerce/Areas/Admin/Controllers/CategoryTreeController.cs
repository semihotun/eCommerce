using AutoMapper;
using Business.Services.CategoriesAggregate.Categories;
using Business.Services.CategoriesAggregate.CategorySpefications;
using Business.Services.SpeficationAggregate.SpecificationAttributes;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using Entities.Concrete.CategoriesAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CategoriesAggregate.Categories;
using Entities.RequestModel.CategoriesAggregate.CategorySpefications;
using Entities.ViewModels.AdminViewModel.CategoryTree;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
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
            ResponseAlert(await _categoryService.ChangeNodePosition(new(id, parentId)));
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
            var data = categoryDetail.MapTo<InsertCategoryReqModel>();
            ResponseAlert(await _categoryService.InsertCategory(data));
            return Json(new { success = true });
        }
        [HttpPost]
        public async Task<JsonResult> DeleteNode(string values)
        {
            ResponseAlert(await _categoryService.DeleteNodes(new(values)));
            Alert("İşlem Başarılı", NotificationType.success);
            return Json(new { success = true });
        }
        #endregion
        public async Task<IActionResult> CategoryEdit(int id)
        {
            return View(new CategoryEditVM
            {
                CategorySpeficationDTO = (await _categoryDAL.GetCategorySpefication(
                new (id))).Data,
                SpeficationAttributeSelectList = (await _specificationAttributeService.GetProductSpeficationAttributeDropdwon(
                new ())).Data
            });
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryEditVM model)
        {
            var data= model.CategorySpeficationDTO.Category.MapTo<UpdateCategoryReqModel>();
            ResponseAlert(await _categoryService.UpdateCategory(data));
            return RedirectToAction(nameof(CategoryEdit), new { id = model.CategorySpeficationDTO.Category.Id });
        }
        public async Task<IActionResult> CategoryFilterDelete(int speficationId, int categoryId)
        {
            var deletedData = await _categorySpeficationService.GetByCategorySpeficationId(new (speficationId, categoryId));
            var data = deletedData.Data.MapTo<DeleteCategorySpeficationReqModel>();
            ResponseAlert(await _categorySpeficationService.DeleteCategorySpefication(data));
            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = deletedData?.Data?.CategoryId });
        }
        [HttpPost]
        public async Task<IActionResult> CategoryFilterCreate(CategoryEditVM model)
        {
            var data = model.CategorySpefication.MapTo<InsertCategorySpeficationReqModel>();
            ResponseAlert(await _categorySpeficationService.InsertCategorySpefication(data));
            return RedirectToAction("CategoryEdit", "CategoryTree", new { id = model.Id });
        }
    }
}