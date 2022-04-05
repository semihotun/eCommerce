using AutoMapper;
using Business.Services.SliderAggregate.Sliders.SliderServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.SliderAggregate.Sliders;
using Entities.Concrete.SliderAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.SliderAggregate.Sliders
{
    public class SliderService : ISliderService
    {
        private readonly ISliderDAL _sliderRepository;
        private readonly IMapper _mapper;
        public SliderService(ISliderDAL sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ISliderService.Get")]
        public async Task<IResult> DeleteSlider(DeleteSlider request)
        {
            if (request.Id == 0)
                return new ErrorResult();

            _sliderRepository.Delete(_sliderRepository.GetById(request.Id));
            await _sliderRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        [CacheAspect]
        public async Task<IDataResult<IList<Slider>>> GetAllSlider()
        {
            var query = _sliderRepository.Query();
            var data = await query.ToListAsync();
            return new SuccessDataResult<List<Slider>>(data);
        }

        [CacheAspect]
        public async Task<IDataResult<Slider>> GetSlider(GetSlider request)
        {
            var data = await _sliderRepository.GetAsync(x => x.Id == request.Id);

            return new SuccessDataResult<Slider>(data);
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ISliderService.Get")]
        public async Task<IResult> InsertSlider(Slider slider)
        {
            if (slider == null)
                return new ErrorResult();

            _sliderRepository.Add(slider);
            await _sliderRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ISliderService.Get")]
        public async Task<IResult> UpdateSlider(Slider slider)
        {
            if (slider == null)
                return new ErrorResult();

            var getSlider = await _sliderRepository.GetAsync(x => x.Id == slider.Id);
            getSlider = _mapper.Map(slider, getSlider);
            _sliderRepository.Update(getSlider);

            await _sliderRepository.SaveChangesAsync();
            return new SuccessResult();

        }
    }
}
