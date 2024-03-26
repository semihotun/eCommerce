#region Using
using AutoMapper;
using Business.Services.BrandAggregate.Brands;
using Business.Services.BrandAggregate.Brands.BrandServiceModel;
using Business.Services.CategoriesAggregate.Categories;
using Business.Services.CategoriesAggregate.Categories.CategoryServiceModel;
using Business.Services.ProductAggregate.ProductAttributeCombinations;
using Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel;
using Business.Services.ProductAggregate.ProductAttributeMappings;
using Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel;
using Business.Services.ProductAggregate.ProductAttributes;
using Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel;
using Business.Services.ProductAggregate.Products;
using Business.Services.ProductAggregate.Products.ProductServiceModel;
using Business.Services.ProductAggregate.ProductStockTypes;
using Business.Services.ProductAggregate.ProductStockTypes.ProductStockTypeServiceModel;
using Business.Services.SpeficationAggregate.SpecificationAttributes;
using Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel;
using Core.Utilities.DataTable;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.Product;
using Entities.Helpers.AutoMapper;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
#endregion
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [AuthorizeControl("")]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class AdminProductController : AdminBaseController
    {
        #region field       
        private readonly IProductService _productService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly IMapper _mapper;
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
         IMapper mapper,
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
            this._mapper = mapper;
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
                BrandSelectListItems = (await _brandService.GetBrandDropdown(new GetBrandDropdown())).Data,
                CategorySelectListItems = (await _categoryService.GetCategoryDropdown(new GetCategoryDropdown())).Data
            });
        }
        public async Task<IActionResult> ProductListJson(ProductDataTableFilter model, DTParameters param) =>
             ToDataTableJson(await _productDAL.GetProductDataTableList(
                new GetProductDataTableList(model, param)), param);
        public async Task<IActionResult> ProductDelete(int Id)
        {
            ResponseAlert(await _productService.DeleteProduct(new DeleteProduct(Id)));
            return RedirectToAction("ProductList", "AdminProduct");
        }
        [HttpGet]
        public async Task<IActionResult> ProductEdit(ProductVM model)
        {
            if (model.Id != 0)
            {
                //Product
                var productTask = await _productService.GetProduct(new GetProduct(model.Id));
                model = _mapper.Map<Product, ProductVM>(productTask.Data);
            }
            var categoryTask = _categoryService.GetCategoryDropdown(new GetCategoryDropdown(model.CategoryId));
            var brandTask = _brandService.GetBrandDropdown(new GetBrandDropdown(model.BrandId));
            var productAttributeTask = _productAttributeService.GetProductAttributeDropdown(new GetProductAttributeDropdown());
            var specificationAttributeTask = _specificationAttributeService.GetProductSpeficationAttributeDropdwon(new GetProductSpeficationAttributeDropdwon());
            var productStockTypeTask = _productStockTypeService.GetAllProductStockType(new GetAllProductStockType(model.ProductStockTypeId));
            var combinationTask = _productAttributeCombinationDal.ProductAttributeCombinationDropDown(new ProductAttributeCombinationDropDown(model.Id));
            var attributeMappingTask = _productAttributeMappingService.GetProductAttributeMappingsByProductId(new GetProductAttributeMappingsByProductId(model.Id));

            await Task.WhenAll(categoryTask, brandTask, productAttributeTask, specificationAttributeTask, productStockTypeTask, combinationTask, attributeMappingTask);

            model.CategorySelectListItems = (await categoryTask).Data;
            model.BrandSelectListItems = (await brandTask).Data;
            model.ProductAttributeSelectlist = (await productAttributeTask).Data;
            model.SpeficationAttributeSelectList = (await specificationAttributeTask).Data;
            model.ProductStockTypeSelectList = (await productStockTypeTask).Data;
            model.CombinationSelectList = (await combinationTask).Data;
            model.ProductAttributeMappingList = (await attributeMappingTask).Data;

            return View(model);
        }
        #endregion
        #region Combination
        public async Task<IActionResult> AttrCombination(int productId, DataTablesParam param) =>
             ToDataTableJson(await _productAttributeCombinationDal.ProductAttributeCombinationDataTable(
                new ProductAttributeCombinationDataTable(productId, param)), param);

        public async Task<IActionResult> AttrCombinationDetail(int combinationId)
        {
            var combinations = await _productAttributeCombinationService.GetProductAttributeCombinationById(
                new GetProductAttributeCombinationById(combinationId));
            var data = _mapper.Map<ProductAttributeCombination, ProductAttributeCombinationVM>(combinations.Data);
            data.AttributesXml = (await _productAttributeFormatter.XmlString(data.AttributesXml));
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AttrCombinationDetail(ProductAttributeCombinationVM model)
        {
            var combinations = model.MapTo<ProductAttributeCombination>();
            ResponseAlert(await _productAttributeCombinationService.UpdateProductAttributeCombination(combinations));
            model.AttributesXml = (await _productAttributeFormatter.XmlString(model.AttributesXml));
            return View(model);
        }
        public async Task<IActionResult> AttrCombinationInsert(int productId)
        {
            ResponseAlert(await _productAttributeCombinationService.AllInsertPermutationCombination(
                new AllInsertPermutationCombination(productId)));
            return RedirectToAction("ProductEdit", "AdminProduct", new { id = productId, Tap = "tap2" });
        }
        #endregion
        #endregion
    }
}