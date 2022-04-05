using AutoMapper;
using Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using Entities.Concrete.ShowcaseAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ShowcaseAggregate.ShowcaseServices
{
    public class ShowcaseService : IShowcaseService
    {
        private readonly IShowcaseDAL _showcaseRepository;
        private readonly IMapper _mapper;

        public ShowcaseService(IShowcaseDAL showcaseRepository, IMapper mapper)
        {
            _showcaseRepository = showcaseRepository;
            _mapper = mapper;
        }

        [CacheAspect]
        public async Task<IDataResult<IList<ShowCase>>> GetAllShowcase()
        {
            var result = _showcaseRepository.Query();
            var data = await result.ToListAsync();

            return new SuccessDataResult<IList<ShowCase>>(data);
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IShowCaseProductService.Get", "IShowcaseService.Get")]
        public async Task<IResult> InsertShowcase(ShowCase showCase)
        {
            if (showCase == null)
                return new ErrorResult();

            _showcaseRepository.Add(showCase);
            await _showcaseRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IShowCaseProductService.Get", "IShowcaseService.Get")]
        public async Task<IResult> DeleteShowCase(DeleteShowCase showCase)
        {
            if (showCase.Id == 0)
                return new ErrorResult();

            var deletedData = _showcaseRepository.GetById(showCase.Id);
            _showcaseRepository.Delete(deletedData);
            await _showcaseRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<ShowCase>> GetShowcase(GetShowcase request)
        {
            var result = await _showcaseRepository.GetAsync(x => x.Id == request.Id);

            return new SuccessDataResult<ShowCase>(result);
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IShowCaseProductService.Get", "IShowcaseService.Get")]
        public async Task<IResult> UpdateShowcase(ShowCase showCase)
        {
            if (showCase == null)
                return new ErrorResult();

            var data = (await GetShowcase(new GetShowcase(showCase.Id))).Data;
            var updateData = _mapper.Map(showCase, data);
            _showcaseRepository.Update(updateData);
            await _showcaseRepository.SaveChangesAsync();
            return new SuccessResult();
        }


    }
}
