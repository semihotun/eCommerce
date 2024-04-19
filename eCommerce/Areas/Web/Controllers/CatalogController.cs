using Business.Constants;
using Business.Services.CategoriesAggregate.Categories.DtoQueries;
using Business.Services.ProductAggregate.Products.DtoQueries;
using Entities.RequestModel.ProductAggregate.Catalog;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Controllers
{
    public class CatalogController : WebBaseController
    {
        #region Ctor
        private readonly ICategoryDtoQueryService _categoryDtoQueryService;
        private readonly IProductDtoQuery _productDtoQuery;
        public CatalogController(ICategoryDtoQueryService categoryDtoQueryService,
            IProductDtoQuery productDtoQuery)
        {
            _categoryDtoQueryService = categoryDtoQueryService;
            _productDtoQuery = productDtoQuery;
        }
        #endregion
        public IActionResult Catalog(Guid id, int pageSize, int pageNumber = 1)
        {
            ViewBag.Sortingenum = ConstList.FillSorting();
            return View(new GetCatalogProductReqModel
            {
                CategoryId = id,
                PageNumber = pageNumber,
                PageSize = pageSize
            });
        }
        public async Task<IActionResult> GetAllCategoryFilter(Guid categoryId)
        {
            var data = (await _categoryDtoQueryService.GetCategorySpeficationOptionDTO(
                new(categoryId))).Data;
            return Json(data, new JsonSerializerSettings());
        }
        public async Task<IActionResult> GetCatalogProduct(GetCatalogProductReqModel model)
        {
            model.Productlist = (await _productDtoQuery.GetCatalogProduct(model)).Data;
            model.ProductCount = (int)Math.Ceiling(model.Productlist!.TotalCount / (decimal)model.PageSize);
            return Json(model, new JsonSerializerSettings());
        }
    }
}
