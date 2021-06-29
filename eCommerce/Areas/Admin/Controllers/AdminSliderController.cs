using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Abstract.Sliders;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using Entities.ViewModels.Admin;
using Entities.Concrete;
using Entities.Helpers.AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utilities.Constants;
using eCommerce.Models;

namespace eCommerce.Areas.Admin.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Kontrol("")]
    [Area("Admin")]
    public class AdminSliderController : AdminBaseController
    {

        #region field
        private readonly IProductService _productService;
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        private IHostingEnvironment _hostingEnvironment;
        #endregion


        #region ctor
        public AdminSliderController(IProductService productService,
            ISliderService sliderService,
            IMapper mapper,
              IHostingEnvironment hostingEnvironment)
        {
            this._productService = productService;
            this._sliderService = sliderService;
            this._mapper = mapper;
            this._hostingEnvironment = hostingEnvironment;
        }
        #endregion


        #region Helper
        public async Task<IActionResult> SliderIndex()
        {
            var model = new SliderModel();
            var entity = await _sliderService.GetAllSlider();
            model.SliderList = _mapper.Map<IList<Slider>, IList<SliderModel>>(entity.Data.ToList());
            return View(model);
        }
        public async Task<IActionResult> SliderEdit(int id = 0)
        {
            var sliderTask = await _sliderService.GetSlider(id);
            SliderModel model = _mapper.Map<Slider, SliderModel>(sliderTask.Data);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SliderEdit(int id, SliderModel model)
        {
            var slider = await _sliderService.GetSlider(id);

            if (model.Uploadfile != null)
            {
                model.SliderImage = new PhotoHelper(_hostingEnvironment).Add(PhotoUrl.ShowCase,
                    model.Uploadfile, true, slider.Data.SliderImage).Data.Path;

                await _sliderService.UpdateSlider(_mapper.Map<SliderModel, Slider>(model));
            }
            else
            {
                model.SliderImage = slider.Data.SliderImage;
            }
            var replaceModel = _mapper.Map<SliderModel, Slider>(model, slider.Data);
            await _sliderService.UpdateSlider(replaceModel);

            return View(model);
        }

        public IActionResult SliderCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SliderCreate(SliderModel model)
        {
            var imageAdd = new PhotoHelper(_hostingEnvironment).Add(PhotoUrl.Slider, model.Uploadfile);
            model.SliderImage = imageAdd.Data.Path;
            await _sliderService.InsertSlider(model.MapTo<Slider>());
            return RedirectToAction("SliderIndex");
        }
        public async Task<IActionResult> SliderDelete(int id)
        {
            var sliderTask = await _sliderService.GetSlider(id);
            var slider = sliderTask.Data;
            await _sliderService.DeleteSlider(id);
            
            if (slider.SliderImage != null)
                 new PhotoHelper(_hostingEnvironment).Delete(Path.Combine(_hostingEnvironment.WebRootPath , PhotoUrl.Slider , slider.SliderImage));

            Alert("Kayıt Silindi", NotificationType.success);
            return Json(true, new JsonSerializerSettings());
        }


        #endregion







    }
}