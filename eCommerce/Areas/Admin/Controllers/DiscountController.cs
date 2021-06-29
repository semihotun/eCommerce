using System;
using System.Globalization;
using AutoMapper;
using Business.Abstract.Discounts;
using DataAccess.Abstract;
using Entities.ViewModels.Admin;
using eCommerce.Helpers;
using Entities.Concrete;
using Entities.DTO.Discount;
using Entities.Others;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Entities.Helpers.AutoMapper;
using Microsoft.VisualBasic;
using eCommerce.Models;

namespace eCommerce.Areas.Admin.Controllers
{
    [Kontrol("")]
    [Route("[area]/[controller]/[action]")]
    [Area("Admin")]
    public class DiscountController : AdminBaseController
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        private readonly IDiscountDAL _discountDal;

        public DiscountController(IDiscountService discountService,
            IMapper mapper, IDiscountDAL discountDal)
        {
            this._discountService = discountService;
            this._mapper = mapper;
            this._discountDal = discountDal;
        }


        public async Task<IActionResult> DiscountListJson(DiscountDataTableFilter model, DataTablesParam param, string approve = null)
        {
            var query = await _discountDal.GetDataTableList(model, param);

            return ToDataTableJson(query, param);
        }

        [HttpGet]
        public IActionResult DiscountList() => View();

        [HttpPost]
        public IActionResult DiscountList(DiscountModel model) => View(model);

        public IActionResult DiscountCreate()
        {
            var model = new DiscountModel();
            model.DiscountLimitationList = SelectListHelper.fillDiscountLimitationType();
            model.DiscountTypeList = SelectListHelper.fillDiscountType();
            return View(model);
        }

        [HttpPost]
        public IActionResult DiscountCreate(DiscountModel model)
        {
            model.DiscountLimitationList = SelectListHelper.fillDiscountLimitationType(model.DiscountLimitationId);
            model.DiscountTypeList = SelectListHelper.fillDiscountType(model.DiscountTypeId);
            var mapData = _mapper.Map<DiscountModel, Discount>(model);
            _discountService.AddDiscount(mapData);

            return View(model);
            //return RedirectToAction("DiscountEdit", "Discount", new { id = mapData.Id });
        }

        public async Task<IActionResult> DiscountEdit(int id = 0)
        {
            var model =(await _discountService.GetDiscount(id)).MapTo<DiscountModel>();
            model.DiscountLimitationList = SelectListHelper.fillDiscountLimitationType(model.DiscountLimitationId);
            model.DiscountTypeList = SelectListHelper.fillDiscountType(model.DiscountTypeId);
            model.StartDateUtcFormat =model.EndDateUtc.ToString("yyyy-MM-ddThh:mm");
            model.EndDateUtcFormat=model.EndDateUtc.ToString("yyyy-MM-ddThh:mm");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DiscountEdit(DiscountModel model)
        {
            model.DiscountLimitationList = SelectListHelper.fillDiscountLimitationType(model.DiscountLimitationId);
            model.DiscountTypeList = SelectListHelper.fillDiscountType(model.DiscountTypeId);
            model.EndDateUtc =DateTime.Parse(model.EndDateUtcFormat);
            model.StartDateUtc = DateTime.Parse(model.StartDateUtcFormat);
            model.EndDateUtc = DateTime.Parse(model.EndDateUtcFormat);

            var mapData = model.MapTo<Discount>();
            await _discountService.UpdateDiscount(mapData);

            return View(model);
        }


        public async Task<IActionResult> DiscountDelete(int id)
        {
            var discountTask = await _discountService.GetDiscount(id);
            await _discountService.DeleteDiscount(discountTask.Data);

            return View(nameof(DiscountList));
        }
    }
}