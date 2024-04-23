#region Using
using Business.Services.BrandAggregate.Brands.Queries;
using Business.Services.CategoriesAggregate.Categories.Queries;
using Business.Services.ProductAggregate.ProductAttributeCombinations.Commands;
using Business.Services.ProductAggregate.ProductAttributeCombinations.DtoQueries;
using Business.Services.ProductAggregate.ProductAttributeCombinations.Queries;
using Business.Services.ProductAggregate.ProductAttributeFormatters;
using Business.Services.ProductAggregate.ProductAttributeMappings.Queries;
using Business.Services.ProductAggregate.ProductAttributes.Queries;
using Business.Services.ProductAggregate.Products.Commands;
using Business.Services.ProductAggregate.Products.DtoQueries;
using Business.Services.ProductAggregate.Products.Queries;
using Business.Services.ProductAggregate.ProductStockTypes.Queries;
using Business.Services.SpeficationAggregate.SpeficationAttributes.Queries;
using Entities.Extensions.AutoMapper;
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
using System;
using System.Threading.Tasks;
#endregion
namespace eCommerce.Areas.Admin.Controllers
{
    public class AdminProductController : AdminBaseController
    {
        #region Ctor      
        private readonly IProductDtoQuery _productDtoQuery;
        private readonly IProductQueryService _productService;
        private readonly IProductCommandService _productCommandService;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly IBrandQueryService _brandQueryService;
        private readonly ICategoryQueryService _categoryQueryService;
        private readonly IProductAttributeCombinationCommandService _productAttributeCombinationCommandService;
        private readonly IProductAttributeCombinationQueryService _productAttributeCombinationQueryService;
        private readonly IProductAttributeCombinationDtoQueryService _productAttributeCombinationDtoQueryService;
        private readonly IProductAttributeQueryService _productAttributeQueryService;
        private readonly ISpecificationAttributeQueryService _specificationAttributeQueryService;
        private readonly IProductStockTypeQueryService _productStockTypeQueryService;
        private readonly IProductAttributeMappingQueryService _productAttributeMappingQueryService;

        public AdminProductController(IProductDtoQuery productDtoQuery,
            IProductQueryService productService,
            IProductCommandService productCommandService,
            IProductAttributeFormatter productAttributeFormatter,
            IBrandQueryService brandQueryService,
            ICategoryQueryService categoryQueryService,
            IProductAttributeCombinationCommandService productAttributeCombinationCommandService,
            IProductAttributeCombinationQueryService productAttributeCombinationQueryService,
            IProductAttributeCombinationDtoQueryService productAttributeCombinationDtoQueryService,
            IProductAttributeQueryService productAttributeQueryService,
            ISpecificationAttributeQueryService specificationAttributeQueryService,
            IProductStockTypeQueryService productStockTypeQueryService,
            IProductAttributeMappingQueryService productAttributeMappingQueryService)
        {
            _productDtoQuery = productDtoQuery;
            _productService = productService;
            _productCommandService = productCommandService;
            _productAttributeFormatter = productAttributeFormatter;
            _brandQueryService = brandQueryService;
            _categoryQueryService = categoryQueryService;
            _productAttributeCombinationCommandService = productAttributeCombinationCommandService;
            _productAttributeCombinationQueryService = productAttributeCombinationQueryService;
            _productAttributeCombinationDtoQueryService = productAttributeCombinationDtoQueryService;
            _productAttributeQueryService = productAttributeQueryService;
            _specificationAttributeQueryService = specificationAttributeQueryService;
            _productStockTypeQueryService = productStockTypeQueryService;
            _productAttributeMappingQueryService = productAttributeMappingQueryService;
        }
        #endregion
        #region Method
        #region Product-Create-List-Update
        public async Task<IActionResult> ProductList()
        {
            return View(new ProductListVM
            {
                BrandSelectListItems = (await _brandQueryService.GetBrandDropdown(new GetBrandDropdownReqModel())).Data,
                CategorySelectListItems = (await _categoryQueryService.GetCategoryDropdown(new GetCategoryDropdownReqModel())).Data
            });
        }
        public async Task<IActionResult> ProductListJson(GetProductDataTableListReqModel model) =>
             ToDataTableJson(await _productDtoQuery.GetProductDataTableList(model), model);
        public async Task<IActionResult> ProductDelete(Guid Id)
        {
            ResponseAlert(await _productCommandService.DeleteProduct(new DeleteProductReqModel(Id)));
            return RedirectToAction("ProductList", "AdminProduct");
        }
        [HttpGet]
        public async Task<IActionResult> ProductEdit(ProductVM model)
        {
            if (model.Id != Guid.Empty)
            {
                //Product
                var productTask = await _productService.GetProduct(new GetProductReqModel(model.Id));
                model = productTask.Data.MapTo<ProductVM>();
            }
            var categoryTask = _categoryQueryService.GetCategoryDropdown(new GetCategoryDropdownReqModel(model.CategoryId));
            var brandTask = _brandQueryService.GetBrandDropdown(new GetBrandDropdownReqModel(model.BrandId));
            var productAttributeTask = _productAttributeQueryService.GetProductAttributeDropdown(new GetProductAttributeDropdownReqModel());
            var specificationAttributeTask = _specificationAttributeQueryService.GetProductSpeficationAttributeDropdwon(new GetProductSpeficationAttributeDropdwonReqModel());
            var productStockTypeTask = _productStockTypeQueryService.GetAllProductStockType(new GetAllProductStockTypeReqModel(model.ProductStockTypeId));
            var attributeMappingTask = _productAttributeMappingQueryService.GetProductAttributeMappingsByProductId(new GetProductAttributeMappingsByProductIdReqModel(model.Id));

            await Task.WhenAll(categoryTask, brandTask, productAttributeTask, specificationAttributeTask, productStockTypeTask, attributeMappingTask);

            model.CategorySelectListItems = (await categoryTask).Data;
            model.BrandSelectListItems = (await brandTask).Data;
            model.ProductAttributeSelectlist = (await productAttributeTask).Data;
            model.SpeficationAttributeSelectList = (await specificationAttributeTask).Data;
            model.ProductStockTypeSelectList = (await productStockTypeTask).Data;
            model.ProductAttributeMappingList = (await attributeMappingTask).Data;
            var combinationTask = _productAttributeCombinationDtoQueryService.ProductAttributeCombinationDropDown(new ProductAttributeCombinationDropDownReqModel(model.Id));
            model.CombinationSelectList = (await combinationTask).Data;
            return View(model);
        }
        #endregion
        #region Combination
        public async Task<IActionResult> AttrCombination(ProductAttributeCombinationDataTableReqModel request) =>
             ToDataTableJson(await _productAttributeCombinationDtoQueryService.ProductAttributeCombinationDataTable(request), request);

        public async Task<IActionResult> AttrCombinationDetail(Guid combinationId)
        {
            var combinations = await _productAttributeCombinationQueryService.GetProductAttributeCombinationById(
                new GetProductAttributeCombinationByIdReqModel(combinationId));
            var data = combinations.Data.MapTo<ProductAttributeCombinationVM>();
            data.AttributesXml = (await _productAttributeFormatter.XmlString(data.AttributesXml));
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AttrCombinationDetail(ProductAttributeCombinationVM model)
        {
            var combinations = model.MapTo<UpdateProductAttributeCombinationReqModel>();
            ResponseAlert(await _productAttributeCombinationCommandService.UpdateProductAttributeCombination(combinations));
            model.AttributesXml = (await _productAttributeFormatter.XmlString(model.AttributesXml));
            return View(model);
        }
        public async Task<IActionResult> AttrCombinationInsert(Guid productId)
        {
            ResponseAlert(await _productAttributeCombinationCommandService.AllInsertPermutationCombination(
                new AllInsertPermutationCombinationReqModel(productId)));
            return RedirectToAction("ProductEdit", "AdminProduct", new { id = productId, Tap = "tap2" });
        }
        #endregion
        #endregion
    }
}