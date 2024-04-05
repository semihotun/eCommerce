using Business.Constants;
using Business.Services.BrandAggregate.Brands;
using Business.Services.BrandAggregate.CatalogBrands;
using Business.Services.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Controllers
{
    public class CatalogController : WebBaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryDAL _categoryDAL;
        private readonly IProductDAL _productDAL;
        private readonly IBrandService _brandService;
        private readonly ICatalogBrandService _catalogBrandService;
        public CatalogController(IProductService productService, ICategoryDAL categoryDAL, IProductDAL productDAL,
            IBrandService brandService
            , ICatalogBrandService catalogBrandService)
        {
            _productService = productService;
            _categoryDAL = categoryDAL;
            _productDAL = productDAL;
            _brandService = brandService;
            _catalogBrandService = catalogBrandService;
        }
        public IActionResult Catalog(int id, int pageSize, int pageNumber = 1)
        {
            var model = new CatalogVM
            {
                CategoryId = id,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            ViewBag.Sortingenum = ConstList.FillSorting();
            return View(model);
        }
        public async Task<IActionResult> GetAllCategoryFilter(int categoryId)
        {
            var data = (await _categoryDAL.GetCategorySpeficationOptionDTO(
                new(categoryId))).Data;
            return Json(data, new JsonSerializerSettings());
        }
        public async Task<IActionResult> GetCatalogProduct(CatalogVM model)
        {
            model.Productlist = (await _productDAL.GetCatalogProduct(model)).Data;
            model.ProductCount = (int)Math.Ceiling(model.Productlist!.TotalCount / (decimal)model.PageSize);
            return Json(model, new JsonSerializerSettings());
        }
        public async Task<IActionResult> GetCatalogBrand(int categoryId)
        {
            var brandList = await _catalogBrandService.GetCatalogBrand(new(categoryId));
            return Json(brandList.Data, new JsonSerializerSettings());
        }
    }
}
