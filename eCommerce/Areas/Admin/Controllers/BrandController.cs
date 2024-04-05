using Business.Services.BrandAggregate.Brands;
using Core.Utilities.DataTable;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands;
using Entities.Concrete.BrandAggregate;
using Entities.Dtos.BrandDALModels;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.BrandAggregate.Brands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class BrandController : AdminBaseController
    {
        #region Field
        private readonly IBrandService _brandService;
        private readonly IBrandDAL _brandDal;
        #endregion
        #region Constructer
        public BrandController(IBrandService brandService,
           IBrandDAL brandDal)
        {
            this._brandService = brandService;
            this._brandDal = brandDal;
        }
        #endregion
        #region Method
        public async Task<IActionResult> BrandListJson(GetBrandDataTable model)
        {
            ResponseDataAlert(await _brandDal.GetBrandDataTable(model), out var result);
            return ToDataTableJson<Brand>(result, model);
        }
        public IActionResult BrandList() => View();
        public async Task<IActionResult> BrandEdit(int id)
        {
            var data = await _brandService.GetBrand(new (id));
            return View(data.Data);
        }
        [HttpPost]
        public async Task<IActionResult> BrandEdit(Brand model)
        {
            var data = model.MapTo<UpdateBrandReqModel>();
            ResponseAlert(await _brandService.UpdateBrand(data));
            return RedirectToAction(nameof(BrandList));
        }
        public IActionResult BrandCreate() => View();
        [HttpPost]
        public async Task<IActionResult> BrandCreate(Brand model)
        {
            var data = model.MapTo<AddBrandReqModel>();
            ResponseAlert(await _brandService.AddBrand(data));
            return View(model);
        }
        public async Task<IActionResult> BrandDelete(int id)
        {
            ResponseAlert(await _brandService.DeleteBrand(new(id)));
            return RedirectToAction("BrandList", "Brand");
        }
        #endregion
    }
}
