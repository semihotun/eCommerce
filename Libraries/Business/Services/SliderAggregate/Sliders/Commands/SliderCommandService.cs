using Core.Extension;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.SliderAggregate.Sliders;
using System.Threading.Tasks;

namespace Business.Services.SliderAggregate.Sliders.Commands
{
    public class SliderCommandService : ISliderCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<Slider> _sliderRepository;

        public SliderCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<Slider> sliderRepository)
        {
            _unitOfWork = unitOfWork;
            _sliderRepository = sliderRepository;
        }

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

                if (request.Uploadfile != null)
                {
                    request.SliderImage = request.Uploadfile.ConvertImageToBase64();
                }
                else
                {
                    request.SliderImage = slider.SliderImage;
                }

                var data = request.MapTo(slider);
                _sliderRepository.Update(data);
                return Result.SuccessResult();
            });
        }
    }
}
