using Business.Abstract;
using Business.Abstract.Showcases;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
namespace Business.Concrete.Showcases
{
    public class ShowcaseService : IShowcaseService
    {
        private readonly IShowcaseDAL _showcaseRepository;
        private readonly IMapper _mapper;

        public ShowcaseService(IShowcaseDAL showcaseRepository, IMapper mapper)
        {
            this._showcaseRepository = showcaseRepository;
            _mapper = mapper;
        }


        public async Task<IDataResult<IList<ShowCase>>> GetAllShowcase()
        { 
            var result = _showcaseRepository.Query();
            var data =await result.ToListAsync();

            return new SuccessDataResult<IList<ShowCase>>(data);
        }

        public async Task<IResult> InsertShowcase(ShowCase showCase)
        {
            if (showCase == null)
                return new ErrorResult();

            _showcaseRepository.Add(showCase);
            await _showcaseRepository.SaveChangesAsync();

            return new SuccessResult();
        }
        public async Task<IResult> DeleteShowCase(int id)
        {
            if (id == 0)
                return new ErrorResult();

            var deletedData = _showcaseRepository.GetById(id);
            _showcaseRepository.Delete(deletedData);
            await _showcaseRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        public async Task<IDataResult<ShowCase>> GetShowcase(int id)
        {
            var result =await _showcaseRepository.GetAsync(x=>x.Id==id);

            return new SuccessDataResult<ShowCase>(result);
        }

        public async Task<IResult> UpdateShowcase(ShowCase showCase)
        {
            if (showCase == null)
                return new ErrorResult();

            var data =(await GetShowcase(showCase.Id)).Data;
            var updateData = _mapper.Map(showCase,data);
            _showcaseRepository.Update(updateData);
            await _showcaseRepository.SaveChangesAsync();
            return new SuccessResult();
        }

  
    }
}
