using AutoMapper;
using Business.Services.SliderAggregate.Sliders;
using Core.Utilities.Identity;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.SliderAggregate.Sliders;
using Entities.ViewModels.AdminViewModel.AdminSlider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class AdminSliderController : AdminBaseController
    {
        #region field
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        #endregion
        #region ctor
        public AdminSliderController(
            ISliderService sliderService,
            IMapper mapper
             )
        {
            this._sliderService = sliderService;
            this._mapper = mapper;
        }
        #endregion
        #region Helper
        public async Task<IActionResult> SliderIndex()
        {
            return View(new SliderListVM
            {
                SliderList = (await _sliderService.GetAllSlider()).Data
            });
        }
        public async Task<IActionResult> SliderEdit(int id)
        {
            var slider = await _sliderService.GetSlider(new (id));
            var data = slider.Data.MapTo<UpdateSliderReqModel>();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> SliderEdit(UpdateSliderReqModel model)
        {
            ResponseAlert(await _sliderService.UpdateSlider(model));
            return RedirectToAction(nameof(SliderIndex));
        }
        public IActionResult SliderCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SliderCreate(InsertSliderReqModel model)
        {
            ResponseAlert(await _sliderService.InsertSlider(model));
            return RedirectToAction("SliderIndex");
        }
        public async Task<IActionResult> SliderDelete(int id)
        {
            ResponseAlert(await _sliderService.DeleteSlider(new DeleteSliderReqModel(id)));
            return Json(true, new JsonSerializerSettings());
        }
        #endregion
    }
}