using AutoMapper;
using Business.Services.DiscountsAggregate.Discounts;
using Business.Services.DiscountsAggregate.Discounts.DiscountServiceModel;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts.DiscountDALModels;
using eCommerce.Helpers;
using Entities.Concrete.DiscountsAggregate;
using Entities.DTO.Discount;
using Entities.Helpers.AutoMapper;
using Entities.Others;
using Entities.ViewModels.AdminViewModel.Discount;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
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

        public async Task<IActionResult> DiscountListJson(DiscountDataTableFilter model, DataTablesParam param, 
            string approve = null)
        {
            var query = await _discountDal.GetDataTableList(
                new GetDataTableList(model, param));

            return ToDataTableJson(query, param);
        }

        [HttpGet]
        public IActionResult DiscountList() => View();

        public IActionResult DiscountCreate()
        {
            var model = new DiscountCreateOrUpdateVM();
            model.DiscountLimitationList = SelectListHelper.FillDiscountLimitationType();
            model.DiscountTypeList = SelectListHelper.FillDiscountType();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DiscountCreate(DiscountCreateOrUpdateVM model)
        {
            model.DiscountLimitationList = SelectListHelper.FillDiscountLimitationType(model.DiscountLimitationId);
            model.DiscountTypeList = SelectListHelper.FillDiscountType(model.DiscountTypeId);

            var mapData = _mapper.Map<DiscountCreateOrUpdateVM, Discount>(model);
            ResponseAlert(await _discountService.AddDiscount(mapData));

            return View(model);
        }

        public async Task<IActionResult> DiscountEdit(int id = 0)
        {
            var model =(await _discountService.GetDiscount(new GetDiscount(id))).Data.MapTo<DiscountCreateOrUpdateVM>();

            model.DiscountLimitationList = SelectListHelper.FillDiscountLimitationType(model.DiscountLimitationId);
            model.DiscountTypeList = SelectListHelper.FillDiscountType(model.DiscountTypeId);

            model.StartDateUtcFormat =model.EndDateUtc.ToString("yyyy-MM-ddThh:mm");
            model.EndDateUtcFormat=model.EndDateUtc.ToString("yyyy-MM-ddThh:mm");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DiscountEdit(DiscountCreateOrUpdateVM model)
        {
            model.DiscountLimitationList = SelectListHelper.FillDiscountLimitationType(model.DiscountLimitationId);
            model.DiscountTypeList = SelectListHelper.FillDiscountType(model.DiscountTypeId);

            model.EndDateUtc =DateTime.Parse(model.EndDateUtcFormat);
            model.StartDateUtc = DateTime.Parse(model.StartDateUtcFormat);
            model.EndDateUtc = DateTime.Parse(model.EndDateUtcFormat);

            var mapData = model.MapTo<Discount>();
            ResponseAlert(await _discountService.UpdateDiscount(mapData));

            return View(model);
        }

        public async Task<IActionResult> DiscountDelete(int id)
        {
            var discountTask = await _discountService.GetDiscount(new GetDiscount(id));
            ResponseAlert(await _discountService.DeleteDiscount(discountTask.Data));

            return View(nameof(DiscountList));
        }
    }
}