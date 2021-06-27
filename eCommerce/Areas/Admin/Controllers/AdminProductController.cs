#region Using
using AutoMapper;
using Business.Abstract;
using Business.Abstract.Brands;
using Business.Abstract.Categories;
using Business.Abstract.Photos;
using Business.Abstract.Products;
using Business.Abstract.Spefications;
using Business.Validation.FluentValidation;
using Core.Utilities.Helper;
using DataAccess.Abstract;
using eCommerce.Attribute;
using eCommerce.Helpers;
using Entities.Concrete;
using Entities.DTO.Product;
using Entities.Others;
using Entities.ViewModels.Admin;
using Entities.ViewModels.Admin.Products.ProductStock;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Entities.Helpers.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Utilities.Constants;
using X.PagedList;
using eCommerce.Models;
#endregion


namespace eCommerce.Areas.Admin.Controllers
{
    [Kontrol("")]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class AdminProductController : AdminBaseController
    {
        #region field       
        private readonly IProductService _productService;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly IMapper _mapper;
        private IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICategoryService _categoryService;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly IProductAttributeCombinationService _productAttributeCombinationService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductAttributeValueService _productAttributeValueService;
        private readonly ICombinationPhotoService _combinationPhotoService;
        private readonly IProductSpecificationAttributeService _productSpecificationAttributeService;
        private readonly ISpecificationAttributeOptionService _specificationAttributeOptionService;
        private readonly ICombinationPhotoDAL _combinationPhotoDAL;
        private readonly IProductSpecificationAttributeDAL _productSpecificationAttributeDAL;
        private readonly IProductDAL _productDAL;
        private readonly IBrandService _brandService;
        private readonly IProductAttributeCombinationDAL _productAttributeCombinationDal;
        private readonly IProductStockService _productStockService;
        private readonly IProductStockDAL _productStockDal;
        private readonly IProductStockTypeService _productStockTypeService;
        private readonly IProductShipmentInfoService _productShipmentInfoService;
        #endregion

        #region ctor
        public AdminProductController(IProductService productService,
         IProductAttributeService productAttributeService,
         IProductAttributeFormatter productAttributeFormatter,
         IMapper mapper,
         IHostingEnvironment hostingEnvironment,
         IHttpContextAccessor httpContextAccessor,
         ICategoryService categoryService,
         ISpecificationAttributeService specificationAttributeService,
         IProductAttributeCombinationService productAttributeCombinationService,
         IProductAttributeMappingService productAttributeMappingService,
         IProductAttributeValueService productAttributeValueService,
         ICombinationPhotoService combinationPhotoService,
         IProductSpecificationAttributeService productSpecificationAttributeService,
         ISpecificationAttributeOptionService specificationAttributeOptionService,
         ICombinationPhotoDAL combinationPhotoDAL,
         IProductSpecificationAttributeDAL productSpecificationAttributeDAL,
         IProductDAL productDAL,
         IBrandService brandService,
         IProductAttributeCombinationDAL productAttributeCombinationDal,
         IProductStockService productStockService,
         IProductStockDAL productStockDal,
         IProductStockTypeService productStockTypeService, IProductShipmentInfoService productShipmentInfoService)
        {
            this._productAttributeFormatter = productAttributeFormatter;
            this._productAttributeService = productAttributeService;
            this._productService = productService;
            this._mapper = mapper;
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            this._categoryService = categoryService;
            this._specificationAttributeService = specificationAttributeService;
            this._productAttributeCombinationService = productAttributeCombinationService;
            this._productAttributeMappingService = productAttributeMappingService;
            this._productAttributeValueService = productAttributeValueService;
            this._combinationPhotoService = combinationPhotoService;
            this._productSpecificationAttributeService = productSpecificationAttributeService;
            this._specificationAttributeOptionService = specificationAttributeOptionService;
            this._combinationPhotoDAL = combinationPhotoDAL;
            this._productSpecificationAttributeDAL = productSpecificationAttributeDAL;
            this._productDAL = productDAL;
            _brandService = brandService;
            _productAttributeCombinationDal = productAttributeCombinationDal;
            _productStockService = productStockService;
            _productStockDal = productStockDal;
            _productStockTypeService = productStockTypeService;
            _productShipmentInfoService = productShipmentInfoService;
        }
        #endregion

        #region Utilities
        [NonAction]
        public async Task ProductEditFillSelectList(ProductModel model)
        {
            model.CategorySelectListItems = (await _categoryService.GetCategoryDropdown(model.CategoryId)).Data;
            model.BrandSelectListItems = (await _brandService.GetBrandDropdown(model.BrandId)).Data;
            model.ProductAttributeSelectlist = (await _productAttributeService.GetProductAttributeDropdown()).Data;
            model.SpeficationAttributeSelectList = (await _specificationAttributeService.GetProductSpeficationAttributeDropdwon()).Data;
            model.CombinationSelectList = (await _productAttributeCombinationDal.ProductAttributeCombinationDropDown(model.Id)).Data;
            model.ProductStockTypeSelectList = (await _productStockTypeService.GetAllProductStockType(model.ProductStockTypeId)).Data;
        }

        #endregion

        #region Method
            
        #region Mapping-AttrValue
        public async Task<IActionResult> GetMappingAttributeValue(int id)
        {
            var data = await _productAttributeValueService.GetProductAttributeValueById(id);
            return Json(data.Data, new JsonSerializerSettings());
        }
        public async Task<IActionResult> AttrMapingDelete(int id)
        {
            await _productAttributeMappingService.DeleteProductAttributeMapping(id);

            return Json(true, new JsonSerializerSettings());
        }
        public async Task<IActionResult> AddProductAttirubeMapping([FromBody] ProductAttributeMapping mappings)
        {
            await _productAttributeMappingService.InsertProductAttributeMapping(mappings);

            return Json(mappings, new JsonSerializerSettings());
        }
        [ValidationaAspect(typeof(ProductAttributeValueValidator))]
        public async Task<IActionResult> UpdateProductMappingAttributeValue([FromBody] ProductModel productModel)
        {
            await _productAttributeValueService.UpdateProductAttributeValue(productModel.ProductAttributeValue);

            return Json(productModel.ProductAttributeValue, new JsonSerializerSettings());
        }
        [ValidationaAspect(typeof(ProductAttributeValueValidator))]
        public async Task<IActionResult> AddProductEditPageMappingAttributeValue([FromBody] ProductModel productModel)
        {

            await _productAttributeValueService.InsertProductAttributeValue(productModel.ProductAttributeValue);

            return Json(productModel.ProductAttributeValue, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ProductAttributeValueList(int productAttrMapingId)
        {
            var result = await _productAttributeValueService.GetProductAttributeValues(productAttrMapingId);

            return Json(result.Data, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ProductAttributeValueDelete(int AttributeValueid)
        {
            await _productAttributeValueService.DeleteProductAttributeValue(AttributeValueid);
            return Json(AttributeValueid, new JsonSerializerSettings());
        }

        #endregion

        #region ProductInfo
        public async Task<IActionResult> ProductInfoCreateOrUpdate(ProductModel model)
        {
            var data = model.MapTo<Product>();
            if (model.Id == 0)
                await _productService.AddProduct(data);
            else
                await _productService.UpdateProduct(data);

            return Json(data, new JsonSerializerSettings());
        }



        #endregion

        #region Product-Create-List-Update
        public async Task<IActionResult> ProductList(int page = 1, int pageSize = 5)
        {
            var model = new ProductListModel();
            model.BrandSelectListItems = (await _brandService.GetBrandDropdown()).Data;
            model.CategorySelectListItems = (await _categoryService.GetCategoryDropdown()).Data;

            return View(model);
        }
        public async Task<IActionResult> ProductListJson(ProductDataTableFilter model, DataTablesParam param)
        {
            var result = await _productDAL.GetProductDataTableList(model, param);
            return ToDataTableJson(result, param);
        }
        public async Task<IActionResult> ProductDelete(int Id)
        {
            await _productService.DeleteProduct(Id);
            return RedirectToAction("ProductList", "AdminProduct");
        }
        [HttpGet]
        public async Task<IActionResult> ProductEdit(ProductModel model)
        {
            if (model.Id != 0)
            {
                //Product
                var productTask = await _productService.GetProduct(id: model.Id);
                model = _mapper.Map<Product, ProductModel>(productTask.Data);
                //Sabit List
                await ProductEditFillSelectList(model);
                //ProductMapping
                var mappingListTask = await _productAttributeMappingService.GetProductAttributeMappingsByProductId(model.Id);
                model.ProductAttributeMappingList = _mapper.Map<List<ProductAttributeMapping>, List<ProductAttributeMappingModel>>(mappingListTask.Data.ToList());
                return View(model);
            }
            //Sabit List
            await ProductEditFillSelectList(model);

            return View(model);
        }

        #endregion

        #region Combination

        public async Task<IActionResult> AttrCombination(int productId, DataTablesParam param)
        {
            var combination = await _productAttributeCombinationDal.ProductAttributeCombinationDataTable(productId, param);

            return ToDataTableJson(combination, param);

        }
        public async Task<IActionResult> AttrCombinationDetail(int combinationId)
        {
            var combinations = await _productAttributeCombinationService.GetProductAttributeCombinationById(combinationId);
            var data = _mapper.Map<ProductAttributeCombination, ProductAttributeCombinationModel>(combinations.Data);
            data.AttributesXml = (await _productAttributeFormatter.XmlString(data.AttributesXml));
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> AttrCombinationDetail(ProductAttributeCombinationModel model)
        {

            var combinations = model.MapTo<ProductAttributeCombination>();
            await _productAttributeCombinationService.UpdateProductAttributeCombination(combinations);

            var data = _mapper.Map<ProductAttributeCombination, ProductAttributeCombinationModel>(combinations);
            data.AttributesXml = (await _productAttributeFormatter.XmlString(data.AttributesXml));

            return View(data);
        }
        public IActionResult AttrCombinationDelete(int Id, int Productid)
        {

            var Combination = _productAttributeCombinationService.GetProductAttributeCombinationById(Id);
            _productAttributeCombinationService.DeleteProductAttributeCombination(Id);
            return Json(true, new JsonSerializerSettings());

            return Json(null);
        }
        public async Task<IActionResult> AttrCombinationinsert(int ProductId)
        {
            List<List<int>> Data = new List<List<int>>();
            var mappingTask = await _productAttributeMappingService.GetProductAttributeMappingsByProductId(ProductId);
            foreach (var item in mappingTask.Data)
            {
                var smallData = new List<int>();
                var attributes = await _productAttributeValueService.GetProductAttributeValues(item.Id);
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
            var permutation = new Attributehelper().Permutations(Data);
            await _productAttributeCombinationService.InsertPermutationCombination(permutation, ProductId);
            return RedirectToAction("ProductEdit", "AdminProduct", new { id = ProductId, Tap = "tap2" });
        }

        #endregion

        #region Photo
        public async Task<IActionResult> PhotoCombinationdata(int productId = 4)
        {
            var data = await _productAttributeCombinationDal.ProductCombinationMappingAttrXml(productId);

            return Json(data.Data, new JsonSerializerSettings());
        }
        public IActionResult AddProductPhoto(ProductPhotoModel productPhoto)
        {
            var newProductPhotoList = new List<ProductPhoto>();
            foreach (var item in productPhoto.ResimDosya)
            {
                var imageAdd = new PhotoHelper(_hostingEnvironment).Add(PhotoUrl.Product, item);
                var resim = new ProductPhoto();
                resim.ProductPhotoName = imageAdd.Data.Path;
                resim.ProductId = productPhoto.ProductId;
                _productService.productPhotoInsert(resim);
                newProductPhotoList.Add(resim);
            }
            return Json(newProductPhotoList, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ProductPhotoList(int productId, DataTablesParam param)
        {
            var query = await _productService.GetProductPhoto(id: productId, pageIndex:
                param.PageIndex, pageSize:
                param.PageSize,
                orderByText: param.ColumnOrder);

            return ToDataTableJson(query, param);
        }
        public async Task<IActionResult> ProductPhotoListDelete(int id, int productId)
        {
            await _productService.productPhotoDelete(id);

            return Json(true, new JsonSerializerSettings());
        }
        public async Task<IActionResult> PhotoCombinationAdded(CombinationPhotoModel combinationPhotoModel)
        {

            await _combinationPhotoService.InsertCombinationPhotos(combinationPhotoModel.PhotoId, combinationPhotoModel.Combinations, combinationPhotoModel.NotCombinations);

            return Json(combinationPhotoModel, new JsonSerializerSettings());
        }
        public IActionResult PhotoSelectedCombination(int productId, int photoId)
        {
            var data = _combinationPhotoDAL.GetAllCombinationPhotos(productId, photoId).Data.ToList();

            return Json(data, new JsonSerializerSettings());
        }

        #endregion

        #region Spefication
        public async Task<IActionResult> ProductSpeficationJson(ProductModel model, DataTablesParam param)
        {
            var query = await _productSpecificationAttributeDAL.ProductSpecAttrList(x => x.ProductId == model.Id, param);

            return ToDataTableJson(query, param);
        }

        [ValidationaAspect(typeof(ProductSpecificationAttributeValidator))]
        public async Task<IActionResult> ProductSpeficationCreate(ProductSpecificationAttributeModel productSpecificationAttribute)
        {
            var data = productSpecificationAttribute.MapTo<ProductSpecificationAttribute>();
            await _productSpecificationAttributeService.InsertProductSpecificationAttribute(data);
            productSpecificationAttribute.Id = data.Id;

            return Json(productSpecificationAttribute, new JsonSerializerSettings());
        }

        public async Task<IActionResult> GetSpeficationOptionById(int speficationAttrId = 0)
        {
            var data = await _specificationAttributeOptionService.GetSpecificationAttributeOptionsBySpecificationAttribute(
                specificationAttributeIdint: speficationAttrId);

            var result = data.Data.Select(x => new SpecificationAttributeOption
            {
                Id = x.Id,
                Name = x.Name
            });
            return Json(result, new JsonSerializerSettings());
        }

        public async Task<IActionResult> ProductSpeficationDelete(int id)
        {

            await _productSpecificationAttributeService.DeleteProductSpecificationAttribute(id);
            return Json(id, new JsonSerializerSettings());
        }


        #endregion

        #region ProductStock
        public async Task<IActionResult> ProductStockListJson(ProductStockFilter productStockFilter, DataTablesParam param)
        {
            var query = await _productStockDal.GetAllProductStockDto(productStockFilter.ProductId, param);

            return ToDataTableJson(query, param);
        }
        public async Task<IActionResult> ProductStockAdd(ProductStockCreateOrUpdate productStock)
        {
            var data = productStock.MapTo<ProductStock>();
            await _productStockService.AddProductStock(data);
            productStock.Id = data.Id;

            return Json(productStock, new JsonSerializerSettings());
        }
        public async Task<IActionResult> ProductStockDelete(int id)
        {
            await _productStockService.DeleteProductStock(id);

            return Json(true, new JsonSerializerSettings());
        }
        #endregion

        #region ProductShipment
        public async Task<IActionResult> ProductShipmentInfoAddOrUpdate(ProductShipmentInfo productShipmentInfo)
        {
            var data= await _productShipmentInfoService.AddOrUpdateProductShipmentInfo(productShipmentInfo);
            
            return Json(productShipmentInfo, new JsonSerializerSettings());
        }

        public async Task<IActionResult> GetProductShipmentInfo(int ProductId)
        {
            var data = (await _productShipmentInfoService.GetProductShipmentInfo(ProductId)).Data;

            return Json(data, new JsonSerializerSettings());
        }

        #endregion

        #endregion

    }
}