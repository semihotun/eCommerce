using AutoMapper;
using Business.Services.SliderAggregate.Sliders.SliderServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.SliderAggregate.Sliders;
using DataAccess.UnitOfWork;
using Entities.Concrete.SliderAggregate;
using Entities.Helpers.AutoMapper;
using Entities.ViewModels.AdminViewModel.AdminSlider;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Utilities.Constants;
namespace Business.Services.SliderAggregate.Sliders
{
    public class SliderService : ISliderService
    {
        private readonly ISliderDAL _sliderRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SliderService(ISliderDAL sliderRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [CacheRemoveAspect("ISliderService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> DeleteSlider(DeleteSlider request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var slider =await _sliderRepository.GetByIdAsync(request.Id);
                if (slider == null)
                    return Result.ErrorResult();
                _sliderRepository.Remove(slider);
                if (slider.SliderImage != null)
                    PhotoHelper.Delete(Path.Combine(PhotoUrl.Slider, slider.SliderImage));
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<List<Slider>>> GetAllSlider()
        {
            return Result.SuccessDataResult(await _sliderRepository.Query().ToListAsync());
        }
        [CacheAspect]
        public async Task<Result<Slider>> GetSlider(GetSlider request)
        {
            return Result.SuccessDataResult<Slider>(await _sliderRepository.GetAsync(x => x.Id == request.Id));
        }
        [CacheRemoveAspect("ISliderService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> InsertSlider(SliderCreateOrUpdateVM model)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var imageAdd = PhotoHelper.Add(PhotoUrl.Slider, model.Uploadfile);
                model.SliderImage = imageAdd.Data.Path;
                var sliderData = model.MapTo<Slider>();
                await _sliderRepository.AddAsync(sliderData);
                return Result.SuccessResult();
            });
        }
        [CacheRemoveAspect("ISliderService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> UpdateSlider(SliderCreateOrUpdateVM model)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var slider = await _sliderRepository.GetAsync(x => x.Id == model.Id);
                if (slider == null)
                    return Result.ErrorResult();
                if (model.Uploadfile != null)
                {
                    model.SliderImage = PhotoHelper.Add(PhotoUrl.ShowCase,
                        model.Uploadfile, true, slider.SliderImage).Data.Path;
                    slider = _mapper.Map(model, slider);
                    _sliderRepository.Update(slider);
                }
                return Result.SuccessResult();
            });
        }
    }
}
