using Business.Abstract;
using Business.Abstract.Sliders;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Validation.FluentValidation;
//using Core.Aspects.Autofac.Validation;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Business.Concrete.Sliders
{
    public class SliderService : ISliderService
    {
        private readonly ISliderDAL _sliderRepository;
        private readonly IMapper _mapper;
        public SliderService(ISliderDAL sliderRepository,IMapper mapper)
        {
            this._sliderRepository = sliderRepository;
            this._mapper = mapper;
        }


        public async Task<IResult> DeleteSlider(int id)
        {
            if (id == 0)
                return new ErrorResult();

            _sliderRepository.Delete(_sliderRepository.GetById(id));
            await _sliderRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IDataResult<IList<Slider>>> GetAllSlider()
        {
            var query = _sliderRepository.Query();
            var data = await query.ToListAsync();
            return new SuccessDataResult<List<Slider>>(data);
        }

        public async Task<IDataResult<Slider>> GetSlider(int id)
        {
            var data=await _sliderRepository.GetAsync(x=>x.Id==id);

            return new SuccessDataResult<Slider>(data);
        }

        public async Task<IResult> InsertSlider(Slider slider)
        {
            if (slider == null)
                return new ErrorResult();

            _sliderRepository.Add(slider);
            await _sliderRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        public async Task<IResult> UpdateSlider(Slider slider)
        {
            if (slider == null)
                return new ErrorResult();

            var getSlider =await _sliderRepository.GetAsync(x=>x.Id == slider.Id);
            getSlider = _mapper.Map(slider,getSlider);
            _sliderRepository.Update(getSlider);

            await _sliderRepository.SaveChangesAsync();
            return new SuccessResult();

        }
    }
}
