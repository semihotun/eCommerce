using AutoMapper;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices;
using DataAccess.UnitOfWork;
using Entities.Concrete.ShowcaseAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
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
        #region Method
        #region Command
        /// <summary>
        /// UpdateShowcase
        /// </summary>
        /// <param name="showCase"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IShowCas")]
        public async Task<Result> UpdateShowcase(UpdateShowcaseReqModel showCase)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _showcaseRepository.GetByIdAsync(showCase.Id);
                if (data == null)
                    return Result.ErrorResult();
                var updateData = _mapper.Map(showCase, data);
                _showcaseRepository.Update(updateData);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertShowcase
        /// </summary>
        /// <param name="showCase"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IShowCase")]
        public async Task<Result<ShowCase>> InsertShowcase(InsertShowcaseReqModel showCase)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = showCase.MapTo<ShowCase>();
                await _showcaseRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// DeleteShowCase
        /// </summary>
        /// <param name="showCase"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IShowCase")]
        public async Task<Result> DeleteShowCase(DeleteShowCaseReqModel showCase)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _showcaseRepository.GetByIdAsync(showCase.Id);
                if (data == null)
                    return Result.ErrorResult();
                _showcaseRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetAllShowcase
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IList<ShowCase>>> GetAllShowcase()
        {
            return Result.SuccessDataResult<IList<ShowCase>>(await _showcaseRepository.Query().ToListAsync());
        }
        /// <summary>
        /// GetShowcase
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ShowCase>> GetShowcase(GetShowcaseReqModel request)
        {
            var data = await _showcaseRepository.GetByIdAsync(request.Id);
            return Result.SuccessDataResult(data);
        }
        #endregion
        #endregion
    }
}
