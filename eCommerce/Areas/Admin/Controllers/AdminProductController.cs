#region Using
using AutoMapper;
using Business.Services.BrandAggregate.Brands;
using Business.Services.CategoriesAggregate.Categories;
using Business.Services.ProductAggregate.ProductAttributeCombinations;
using Business.Services.ProductAggregate.ProductAttributeMappings;
using Business.Services.ProductAggregate.ProductAttributes;
using Business.Services.ProductAggregate.Products;
using Business.Services.ProductAggregate.ProductStockTypes;
using Business.Services.SpeficationAggregate.SpecificationAttributes;
using Core.Utilities.DataTable;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductAttributeCombinationDALModels;
using Entities.Dtos.ProductDALModels;
using Entities.Extensions.AutoMapper;
using Entities.Others;
using Entities.RequestModel.BrandAggregate.Brands;
using Entities.RequestModel.CategoriesAggregate.Categories;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using Entities.RequestModel.ProductAggregate.Products;
using Entities.RequestModel.ProductAggregate.ProductStockTypes;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
#endregion
namespace eCommerce.Areas.Admin.Controllers
{
    public class AdminProductController : AdminBaseController
    {
        #region field       
        private readonly IProductService _productService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly ICategoryService _categoryService;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IProductAttributeCombinationService _productAttributeCombinationService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductDAL _productDAL;
        private readonly IBrandService _brandService;
        private readonly IProductAttributeCombinationDAL _productAttributeCombinationDal;
        private readonly IProductStockTypeService _productStockTypeService;
        #endregion
        #region ctor
        public AdminProductController(IProductService productService,
         IProductAttributeService productAttributeService,
         IProductAttributeFormatter productAttributeFormatter,
         ICategoryService categoryService,
         ISpecificationAttributeService specificationAttributeService,
         IProductAttributeCombinationService productAttributeCombinationService,
         IProductAttributeMappingService productAttributeMappingService,
         IProductDAL productDAL,
         IBrandService brandService,
         IProductAttributeCombinationDAL productAttributeCombinationDal,
         IProductStockTypeService productStockTypeService
            )
        {
            this._productAttributeFormatter = productAttributeFormatter;
            this._productAttributeService = productAttributeService;
            this._productService = productService;
            this._categoryService = categoryService;
            this._specificationAttributeService = specificationAttributeService;
            this._productAttributeCombinationService = productAttributeCombinationService;
            this._productAttributeMappingService = productAttributeMappingService;
            this._productDAL = productDAL;
            _brandService = brandService;
            _productAttributeCombinationDal = productAttributeCombinationDal;
            _productStockTypeService = productStockTypeService;
        }
        #endregion
        #region Method
        #region Product-Create-List-Update
        public async Task<IActionResult> ProductList()
        {
            return View(new ProductListVM
            {
                BrandSelectListItems = (await _brandService.GetBrandDropdown(new GetBrandDropdownReqModel())).Data,
                CategorySelectListItems = (await _categoryService.GetCategoryDropdown(new GetCategoryDropdownReqModel())).Data
            });
        }
        public async Task<IActionResult> ProductListJson(ProductDataTableFilter model, DTParameters param) =>
             ToDataTableJson(await _productDAL.GetProductDataTableList(
                new GetProductDataTableList(model, param)), param);
        public async Task<IActionResult> ProductDelete(int Id)
        {
            ResponseAlert(await _productService.DeleteProduct(new DeleteProductReqModel(Id)));
            return RedirectToAction("ProductList", "AdminProduct");
        }
        [HttpGet]
        public async Task<IActionResult> ProductEdit(ProductVM model)
        {
            if (model.Id != 0)
            {
                //Product
                var productTask = await _productService.GetProduct(new GetProductReqModel(model.Id));
                model = productTask.Data.MapTo<ProductVM>();
            }
            var categoryTask = _categoryService.GetCategoryDropdown(new GetCategoryDropdownReqModel(model.CategoryId));
            var brandTask = _brandService.GetBrandDropdown(new GetBrandDropdownReqModel(model.BrandId));
            var productAttributeTask = _productAttributeService.GetProductAttributeDropdown(new GetProductAttributeDropdownReqModel());
            var specificationAttributeTask = _specificationAttributeService.GetProductSpeficationAttributeDropdwon(new GetProductSpeficationAttributeDropdwonReqModel());
            var productStockTypeTask = _productStockTypeService.GetAllProductStockType(new GetAllProductStockTypeReqModel(model.ProductStockTypeId));
            var attributeMappingTask = _productAttributeMappingService.GetProductAttributeMappingsByProductId(new GetProductAttributeMappingsByProductIdReqModel(model.Id));

            await Task.WhenAll(categoryTask, brandTask, productAttributeTask, specificationAttributeTask, productStockTypeTask, attributeMappingTask);

            model.CategorySelectListItems = (await categoryTask).Data;
            model.BrandSelectListItems = (await brandTask).Data;
            model.ProductAttributeSelectlist = (await productAttributeTask).Data;
            model.SpeficationAttributeSelectList = (await specificationAttributeTask).Data;
            model.ProductStockTypeSelectList = (await productStockTypeTask).Data;
            model.ProductAttributeMappingList = (await attributeMappingTask).Data;
            var combinationTask = _productAttributeCombinationDal.ProductAttributeCombinationDropDown(new ProductAttributeCombinationDropDown(model.Id));
            model.CombinationSelectList = (await combinationTask).Data;
            return View(model);
        }
        #endregion
        #region Combination
        public async Task<IActionResult> AttrCombination(int productId, DTParameters param) =>
             ToDataTableJson(await _productAttributeCombinationDal.ProductAttributeCombinationDataTable(
                new ProductAttributeCombinationDataTable(productId, param)), param);

        public async Task<IActionResult> AttrCombinationDetail(int combinationId)
        {
            var combinations = await _productAttributeCombinationService.GetProductAttributeCombinationById(
                new GetProductAttributeCombinationByIdReqModel(combinationId));
            var data = combinations.Data.MapTo<ProductAttributeCombinationVM>();
            data.AttributesXml = (await _productAttributeFormatter.XmlString(data.AttributesXml));
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AttrCombinationDetail(ProductAttributeCombinationVM model)
        {
            var combinations = model.MapTo<UpdateProductAttributeCombinationReqModel>();
            ResponseAlert(await _productAttributeCombinationService.UpdateProductAttributeCombination(combinations));
            model.AttributesXml = (await _productAttributeFormatter.XmlString(model.AttributesXml));
            return View(model);
        }
        public async Task<IActionResult> AttrCombinationInsert(int productId)
        {
            ResponseAlert(await _productAttributeCombinationService.AllInsertPermutationCombination(
                new AllInsertPermutationCombinationReqModel(productId)));
            return RedirectToAction("ProductEdit", "AdminProduct", new { id = productId, Tap = "tap2" });
        }
        #endregion
        #endregion
    }
}