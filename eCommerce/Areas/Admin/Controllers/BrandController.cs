﻿using AutoMapper;
using Business.Services.BrandAggregate.Brands;
using Business.Services.BrandAggregate.Brands.BrandServiceModel;
using Core.Utilities.DataTable;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands.BrandDALModels;
using eCommerce.Models;
using Entities.Concrete.BrandAggregate;
using Entities.DTO.Brand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [Kontrol("")]
    [Area("Admin")]
    public class BrandController : AdminBaseController
    {
        #region Field
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        private readonly IBrandDAL _brandDal;

        #endregion

        #region Constructer
        public BrandController(IBrandService brandService,
           IMapper mapper,
           IBrandDAL brandDal)
        {
            this._brandService = brandService;
            this._mapper = mapper;
            this._brandDal = brandDal;
        }
        #endregion

        #region Method
        public async Task<IActionResult> BrandListJson(BrandDataTableFilter model,DTParameters param,string json)
       {
            var query = await _brandDal.GetBrandDataTable(
                new GetBrandDataTable(model, param));

            return ToDataTableJson<Brand>(query, param);
        }
        public IActionResult BrandList() => View();

        public async Task<IActionResult> BrandEdit(int id)
        {
            var data = await _brandService.GetBrand(new GetBrand(id));
            QueryAlert(data);

            return View(data.Data);
        }

        [HttpPost]
        public async Task<IActionResult> BrandEdit(Brand model)
        {
            ResponseAlert(await _brandService.UpdateBrand(model));

            return View(model);
        }

        public IActionResult BrandCreate() => View();

        [HttpPost]
        public async Task<IActionResult> BrandCreate(Brand model)
        {
            ResponseAlert(await _brandService.BrandAdd(model));

            return RedirectToAction("BrandList", "Brand");

        }
        public async Task<IActionResult> BrandDelete(int id)
        {
            var deletedData = await _brandService.GetBrand(new GetBrand(id));
            ResponseAlert(await _brandService.DeleteBrand(deletedData.Data));

            return RedirectToAction("BrandList", "Brand");
        }

        #endregion

    }
}

