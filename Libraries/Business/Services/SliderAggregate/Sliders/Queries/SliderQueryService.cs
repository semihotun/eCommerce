using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.SliderAggregate.Sliders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.SliderAggregate.Sliders.Queries
{
    public class SliderQueryService : ISliderQueryService
    {
        private readonly IReadDbRepository<Slider> _sliderRepository;

        public SliderQueryService(IReadDbRepository<Slider> sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        /// <summary>
        /// GetAllSlider
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<Slider>>> GetAllSlider()
        {
            var data = await _sliderRepository.ToListAsync();
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
    }
}
