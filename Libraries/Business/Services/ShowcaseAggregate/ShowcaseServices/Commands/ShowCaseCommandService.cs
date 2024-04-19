using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
using System.Threading.Tasks;

namespace Business.Services.ShowcaseAggregate.ShowcaseServices.Commands
{
    public class ShowCaseCommandService : IShowCaseCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ShowCase> _showcaseRepository;

        public ShowCaseCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<ShowCase> showcaseRepository)
        {
            _unitOfWork = unitOfWork;
            _showcaseRepository = showcaseRepository;
        }

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
                data = showCase.MapTo(data);
                _showcaseRepository.Update(data);
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
    }
}
