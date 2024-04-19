using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ShowcaseAggregate.ShowcaseServices.Queries
{
    public class ShowCaseQueryService : IShowCaseQueryService
    {
        private readonly IReadDbRepository<ShowCase> _showcaseRepository;
        public ShowCaseQueryService(IReadDbRepository<ShowCase> showcaseRepository)
        {
            _showcaseRepository = showcaseRepository;
        }

        /// <summary>
        /// GetAllShowcase
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IList<ShowCase>>> GetAllShowcase()
        {
            return Result.SuccessDataResult<IList<ShowCase>>(await _showcaseRepository.ToListAsync());
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
    }
}
