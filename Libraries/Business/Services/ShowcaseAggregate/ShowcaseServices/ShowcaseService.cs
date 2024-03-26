using AutoMapper;
using Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using DataAccess.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;
        public ShowcaseService(IShowcaseDAL showcaseRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _showcaseRepository = showcaseRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [CacheAspect]
        public async Task<Result<IList<ShowCase>>> GetAllShowcase()
        {
            return Result.SuccessDataResult<IList<ShowCase>>(await _showcaseRepository.Query().ToListAsync());
        }
        [CacheRemoveAspect("IShowCaseProductService.Get", "IShowcaseService.Get", "ShowcaseDAL.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> InsertShowcase(ShowCase showCase)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                await _showcaseRepository.AddAsync(showCase);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IShowCaseProductService.Get", "IShowcaseService.Get", "ShowcaseDAL.Get")]
        public async Task<Result> DeleteShowCase(DeleteShowCase showCase)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                var data = await _showcaseRepository.GetByIdAsync(showCase.Id);
                if (data == null)
                    return Result.SuccessResult();
                _showcaseRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<ShowCase>> GetShowcase(GetShowcase request)
        {
            return Result.SuccessDataResult<ShowCase>(await _showcaseRepository.GetAsync(x => x.Id == request.Id));
        }
        [CacheRemoveAspect("IShowCaseProductService.Get", "IShowcaseService.Get", "ShowcaseDAL.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> UpdateShowcase(ShowCase showCase)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = (await GetShowcase(new GetShowcase(showCase.Id))).Data;
                if(data == null)
                    return Result.ErrorResult();
                var updateData = _mapper.Map(showCase, data);
                _showcaseRepository.Update(updateData);
                return Result.SuccessResult();
            });
        }
    }
}
