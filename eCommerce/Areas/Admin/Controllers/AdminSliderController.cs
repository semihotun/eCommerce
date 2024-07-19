using Business.Services.SliderAggregate.Sliders.Commands;
using Business.Services.SliderAggregate.Sliders.DtoQueries;
using Business.Services.SliderAggregate.Sliders.Queries;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.SliderAggregate.Sliders;
using Entities.ViewModels.AdminViewModel.AdminSlider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class AdminSliderController : AdminBaseController
    {
        #region ctor
        private readonly ISliderCommandService _sliderCommandService;
        private readonly ISliderDtoQueryService _sliderDtoQueryService;
        private readonly ISliderQueryService _sliderQueryService;
        public AdminSliderController(ISliderCommandService sliderCommandService,
            ISliderDtoQueryService sliderDtoQueryService,
            ISliderQueryService sliderQueryService)
        {
            _sliderCommandService = sliderCommandService;
            _sliderDtoQueryService = sliderDtoQueryService;
            _sliderQueryService = sliderQueryService;
        }
        #endregion
        #region Helper
        public async Task<IActionResult> SliderIndex()
        {
            return View(new SliderListVM
            {
                SliderList = (await _sliderQueryService.GetAllSlider()).Data
            });
        }
        public async Task<IActionResult> SliderEdit(Guid id)
        {
            var slider = await _sliderQueryService.GetSlider(new(id));
            var data = slider.Data.MapTo<UpdateSliderReqModel>();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> SliderEdit(UpdateSliderReqModel model)
        {
            ResponseAlert(await _sliderCommandService.UpdateSlider(model));
            return RedirectToAction(nameof(SliderIndex));
        }
        public IActionResult SliderCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SliderCreate(InsertSliderReqModel model)
        {
            ResponseAlert(await _sliderCommandService.InsertSlider(model));
            return RedirectToAction("SliderIndex");
        }
        public async Task<IActionResult> SliderDelete(Guid id)
        {
            ResponseAlert(await _sliderCommandService.DeleteSlider(new DeleteSliderReqModel(id)));
            return RedirectToAction(nameof(SliderIndex));
        }
        #endregion
    }
}