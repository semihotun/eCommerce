using AutoMapper;
using Business.Services.SliderAggregate.Sliders;
using Business.Services.SliderAggregate.Sliders.SliderServiceModel;
using Core.Utilities.Identity;
using Entities.Concrete.SliderAggregate;
using Entities.ViewModels.AdminViewModel.AdminSlider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[area]/[controller]/[action]")]
    [AuthorizeControl("")]
    [Area("Admin")]
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
        public async Task<IActionResult> SliderEdit(int id = 0)
        {
            var sliderTask = await _sliderService.GetSlider(new GetSlider(id));
            var model = _mapper.Map<Slider, SliderCreateOrUpdateVM>(sliderTask.Data);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SliderEdit(SliderCreateOrUpdateVM model)
        {
            ResponseAlert(await _sliderService.UpdateSlider(model));
            return RedirectToAction(nameof(SliderIndex));
        }
        public IActionResult SliderCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SliderCreate(SliderCreateOrUpdateVM model)
        {
            ResponseAlert(await _sliderService.InsertSlider(model));
            return RedirectToAction("SliderIndex");
        }
        public async Task<IActionResult> SliderDelete(int id)
        {
            ResponseAlert(await _sliderService.DeleteSlider(new DeleteSlider(id)));
            return Json(true, new JsonSerializerSettings());
        }
        #endregion
    }
}