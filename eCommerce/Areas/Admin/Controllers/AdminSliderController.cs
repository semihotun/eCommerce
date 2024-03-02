using AutoMapper;
using Business.Services.SliderAggregate.Sliders;
using Business.Services.SliderAggregate.Sliders.SliderServiceModel;
using Core.Utilities.Helper;
using Core.Utilities.Identity;
using Entities.Concrete.SliderAggregate;
using Entities.Helpers.AutoMapper;
using Entities.ViewModels.AdminViewModel.AdminSlider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Utilities.Constants;
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
            var model = new SliderListVM();
            model.SliderList= (await _sliderService.GetAllSlider()).Data;
            return View(model);
        }
        public async Task<IActionResult> SliderEdit(int id = 0)
        {
            var sliderTask = await _sliderService.GetSlider(new GetSlider(id));
            var model = _mapper.Map<Slider, SliderCreateOrUpdateVM>(sliderTask.Data);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SliderEdit(int id, SliderCreateOrUpdateVM model)
        {
            var slider = await _sliderService.GetSlider(new GetSlider(id));
            if (model.Uploadfile != null)
            {
                model.SliderImage = new PhotoHelper().Add(PhotoUrl.ShowCase,
                    model.Uploadfile, true, slider.Data.SliderImage).Data.Path;
                await _sliderService.UpdateSlider(_mapper.Map<SliderCreateOrUpdateVM, Slider>(model));
            }
            else
            {
                model.SliderImage = slider.Data.SliderImage;
            }
            var replaceModel = _mapper.Map<SliderCreateOrUpdateVM, Slider>(model, slider.Data);
            ResponseAlert(await _sliderService.UpdateSlider(replaceModel));
            return View(model);
        }
        public IActionResult SliderCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SliderCreate(SliderCreateOrUpdateVM model)
        {
            var imageAdd = new PhotoHelper().Add(PhotoUrl.Slider, model.Uploadfile);
            model.SliderImage = imageAdd.Data.Path;
            ResponseAlert(await _sliderService.InsertSlider(model.MapTo<Slider>()));
            return RedirectToAction("SliderIndex");
        }
        public async Task<IActionResult> SliderDelete(int id)
        {
            var slider = (await _sliderService.GetSlider(new GetSlider(id))).Data;
            ResponseAlert(await _sliderService.DeleteSlider(new DeleteSlider(id)));
            if (slider.SliderImage != null)
                 new PhotoHelper().Delete(Path.Combine( PhotoUrl.Slider , slider.SliderImage));
            return Json(true, new JsonSerializerSettings());
        }
        #endregion
    }
}