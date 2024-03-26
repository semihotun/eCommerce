using Business.Services.BrandAggregate.Brands;
using Business.Services.BrandAggregate.Brands.BrandServiceModel;
using Core.Utilities.DataTable;
using Core.Utilities.Identity;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands.BrandDALModels;
using Entities.Concrete.BrandAggregate;
using Entities.DTO.Brand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [AuthorizeControl("")]
    [Area("Admin")]
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
        public async Task<IActionResult> BrandListJson(BrandDataTableFilter model, DTParameters param)
        {
            ResponseDataAlert(await _brandDal.GetBrandDataTable(new GetBrandDataTable(model, param)), out var result);
            return ToDataTableJson<Brand>(result, param);
        }
        public IActionResult BrandList() => View();
        public async Task<IActionResult> BrandEdit(int id)
        {
            var data = await _brandService.GetBrand(new GetBrand(id));
            return View(data.Data);
        }
        [HttpPost]
        public async Task<IActionResult> BrandEdit(Brand model)
        {
            ResponseAlert(await _brandService.UpdateBrand(model));
            return RedirectToAction(nameof(BrandList));
        }
        public IActionResult BrandCreate() => View();
        [HttpPost]
        public async Task<IActionResult> BrandCreate(Brand model)
        {
            ResponseAlert(await _brandService.AddBrand(model));
            return View(model);
        }
        public async Task<IActionResult> BrandDelete(int id)
        {
            ResponseAlert(await _brandService.DeleteBrand((await _brandService.GetBrand(new GetBrand(id))).Data));
            return RedirectToAction("BrandList", "Brand");
        }
        #endregion
    }
}
