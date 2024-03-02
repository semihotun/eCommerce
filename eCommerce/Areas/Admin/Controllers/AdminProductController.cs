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
using Business.Services.ProductAggregate.ProductAttributeValues;
using Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel;
using Business.Services.ProductAggregate.Products;
using Business.Services.ProductAggregate.Products.ProductServiceModel;
using Business.Services.ProductAggregate.ProductStockTypes;
using Business.Services.ProductAggregate.ProductStockTypes.ProductStockTypeServiceModel;
using Business.Services.SpeficationAggregate.SpecificationAttributes;
using Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel;
using Core.Utilities.DataTable;
using Core.Utilities.Helper;
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
using System.Collections.Generic;
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
        private readonly IProductAttributeValueService _productAttributeValueService;
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
         IProductAttributeValueService productAttributeValueService,
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
            this._productAttributeValueService = productAttributeValueService;
            this._productDAL = productDAL;
            _brandService = brandService;
            _productAttributeCombinationDal = productAttributeCombinationDal;
            _productStockTypeService = productStockTypeService;
        }
        #endregion
        #region Utilities
        [NonAction]
        public async Task ProductEditFillSelectList(ProductVM model)
        {
            var productStockTypeSelectListTask = _productStockTypeService.GetAllProductStockType(new GetAllProductStockType(model.ProductStockTypeId));
            var categorySelectListItemsTask = _categoryService.GetCategoryDropdown(new GetCategoryDropdown(model.CategoryId));
            var brandSelectListItemsTask = _brandService.GetBrandDropdown(new GetBrandDropdown(model.BrandId));
            var productAttributeSelectlistTask = _productAttributeService.GetProductAttributeDropdown(new GetProductAttributeDropdown());
            var speficationAttributeSelectListTask = _specificationAttributeService.GetProductSpeficationAttributeDropdwon(new GetProductSpeficationAttributeDropdwon());
            var combinationSelectListTask = _productAttributeCombinationDal.ProductAttributeCombinationDropDown
                (new ProductAttributeCombinationDropDown(model.Id));
            await Task.WhenAll(
            categorySelectListItemsTask,
            brandSelectListItemsTask,
            productAttributeSelectlistTask,
            speficationAttributeSelectListTask,
            combinationSelectListTask, 
            productStockTypeSelectListTask
           ).ContinueWith((t) =>
           {
               model.CategorySelectListItems = categorySelectListItemsTask.Result.Data;
               model.BrandSelectListItems = brandSelectListItemsTask.Result.Data;
               model.ProductAttributeSelectlist = productAttributeSelectlistTask.Result.Data;
               model.SpeficationAttributeSelectList = speficationAttributeSelectListTask.Result.Data;
               model.CombinationSelectList = combinationSelectListTask.Result.Data;
               model.ProductStockTypeSelectList = productStockTypeSelectListTask.Result.Data;
           });
        }
        #endregion
        #region Method
        #region Product-Create-List-Update
        public async Task<IActionResult> ProductInfoCreateOrUpdate(ProductVM model)
        {
            var data = model.MapTo<Product>();
            if (model.Id == 0)
                ResponseAlert(await _productService.AddProduct(data));
            else
                ResponseAlert(await _productService.UpdateProduct(data));
            return Json(data, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ProductList(int page = 1, int pageSize = 5)
        {
            var model = new ProductListVM();
            var brandSelectListItemsTask = _brandService.GetBrandDropdown(new GetBrandDropdown());
            var categorySelectListItems = _categoryService.GetCategoryDropdown(new GetCategoryDropdown());
            await Task.WhenAll(
                brandSelectListItemsTask, 
                categorySelectListItems).ContinueWith((t) =>
            {
                model.BrandSelectListItems = brandSelectListItemsTask.Result.Data;
                model.CategorySelectListItems = categorySelectListItems.Result.Data;
            });
            return View(model);
        }
        public async Task<IActionResult> ProductListJson(ProductDataTableFilter model, DTParameters param)
        {
            var result = await _productDAL.GetProductDataTableList(
                new GetProductDataTableList(model, param));
            return ToDataTableJson(result, param);
        }
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
            //Sabit List
            await ProductEditFillSelectList(model);
            //ProductMapping
            var mappingListTask = _productAttributeMappingService.GetProductAttributeMappingsByProductId(new GetProductAttributeMappingsByProductId(model.Id));
            await Task.WhenAll(mappingListTask).ContinueWith((t) =>
            {
                model.ProductAttributeMappingList = mappingListTask.Result.Data.ToList();
            });
            return View(model);
        }
        #endregion
        #region Combination
        public async Task<IActionResult> AttrCombination(int productId, DataTablesParam param)
        {
            var combination = await _productAttributeCombinationDal.ProductAttributeCombinationDataTable(
                new ProductAttributeCombinationDataTable(productId, param));
            return ToDataTableJson(combination, param);
        }
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
        public async Task<IActionResult> AttrCombinationDelete(int Id, int Productid)
        {
            var Combination = _productAttributeCombinationService.GetProductAttributeCombinationById(new GetProductAttributeCombinationById(Id));
            ResponseAlert(await _productAttributeCombinationService.DeleteProductAttributeCombination(new DeleteProductAttributeCombination(Id)));
            return Json(true, new JsonSerializerSettings());
        }
        public async Task<IActionResult> AttrCombinationinsert(int ProductId)
        {
            List<List<int>> Data = new List<List<int>>();
            var mappingTask = await _productAttributeMappingService.GetProductAttributeMappingsByProductId(new GetProductAttributeMappingsByProductId(ProductId));
            foreach (var item in mappingTask.Data)
            {
                var smallData = new List<int>();
                var attributes = await _productAttributeValueService.GetProductAttributeValues(new GetProductAttributeValues(item.Id));
                if (attributes.Data.Any())
                {
                    foreach (var smallItem in attributes.Data)
                    {
                        smallData.Add(smallItem.Id);
                    }
                }
                if (smallData.Count > 0)
                    Data.Add(smallData);
            }
            var permutation = new AttributeHelper().Permutations(Data);
            ResponseAlert(await _productAttributeCombinationService.InsertPermutationCombination(
                new InsertPermutationCombination(permutation, ProductId)));
            return RedirectToAction("ProductEdit", "AdminProduct", new { id = ProductId, Tap = "tap2" });
        }
        #endregion
        #endregion
    }
}