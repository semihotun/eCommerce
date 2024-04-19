using Business.Services.BrandAggregate.Brands.Commands;
using Business.Services.BrandAggregate.Brands.DtoQueries;
using Business.Services.BrandAggregate.Brands.Queries;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.BrandAggregate.Brands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class BrandController : AdminBaseController
    {
        #region Field
        private readonly IBrandCommandService _brandCommandService;
        private readonly IBrandDtoQueryService _brandDtoQueryService;
        private readonly IBrandQueryService _brandQueryService;
        public BrandController(IBrandCommandService brandCommandService,
            IBrandDtoQueryService brandDtoQueryService,
            IBrandQueryService brandQueryService)
        {
            _brandCommandService = brandCommandService;
            _brandDtoQueryService = brandDtoQueryService;
            _brandQueryService = brandQueryService;
        }
        #endregion
        #region Method
        public async Task<IActionResult> BrandListJson(GetBrandDataTable model)
        {
            ResponseDataAlert(await _brandDtoQueryService.GetBrandDataTable(model), out var result);
            return ToDataTableJson<Brand>(result, model);
        }
        public IActionResult BrandList() => View();
        public async Task<IActionResult> BrandEdit(Guid id)
        {
            var data = await _brandQueryService.GetBrand(new (id));
            return View(data.Data);
        }
        [HttpPost]
        public async Task<IActionResult> BrandEdit(Brand model)
        {
            var data = model.MapTo<UpdateBrandReqModel>();
            ResponseAlert(await _brandCommandService.UpdateBrand(data));
            return RedirectToAction(nameof(BrandList));
        }
        public IActionResult BrandCreate() => View();
        [HttpPost]
        public async Task<IActionResult> BrandCreate(Brand model)
        {
            var data = model.MapTo<AddBrandReqModel>();
            ResponseAlert(await _brandCommandService.AddBrand(data));
            return View(model);
        }
        public async Task<IActionResult> BrandDelete(Guid id)
        {
            ResponseAlert(await _brandCommandService.DeleteBrand(new(id)));
            return RedirectToAction("BrandList", "Brand");
        }
        #endregion
    }
}
