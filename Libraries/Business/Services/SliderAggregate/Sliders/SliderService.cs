using Core.Aspects.Autofac.Caching;
using Core.Extension;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.SliderAggregate.Sliders;
using DataAccess.UnitOfWork;
using Entities.Concrete.SliderAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.SliderAggregate.Sliders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.SliderAggregate.Sliders
{
    public class SliderService : ISliderService
    {
        private readonly ISliderDAL _sliderRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SliderService(ISliderDAL sliderRepository, IUnitOfWork unitOfWork)
        {
            _sliderRepository = sliderRepository;
            _unitOfWork = unitOfWork;
        }
        #region Method
        #region Command
        /// <summary>
        /// DeleteSlider
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISlider")]
        public async Task<Result> DeleteSlider(DeleteSliderReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var slider = await _sliderRepository.GetByIdAsync(request.Id);
                if (slider == null)
                    return Result.ErrorResult();
                _sliderRepository.Remove(slider);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertSlider
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISlider")]
        public async Task<Result<Slider>> InsertSlider(InsertSliderReqModel model)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                model.SliderImage = model.Uploadfile.ConvertImageToBase64();
                var sliderData = model.MapTo<Slider>();
                await _sliderRepository.AddAsync(sliderData);
                return Result.SuccessDataResult(sliderData);
            });
        }
        /// <summary>
        /// UpdateSlider
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISlider")]
        public async Task<Result> UpdateSlider(UpdateSliderReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var slider = await _sliderRepository.GetByIdAsync(request.Id);
                if (slider == null)
                    return Result.ErrorResult();

                request.SliderImage = request.Uploadfile.ConvertImageToBase64();
                var data = request.MapTo(slider);
                _sliderRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetAllSlider
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<Slider>>> GetAllSlider()
        {
            var data = await _sliderRepository.Query().ToListAsync();
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// GetSlider
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<Slider>> GetSlider(GetSliderReqModel request)
        {
            var data = await _sliderRepository.GetByIdAsync(request.Id);
            return Result.SuccessDataResult(data);
        }
        #endregion
        #endregion
    }
}
