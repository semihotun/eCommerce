using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.PhotoAggregate.CombinationPhotos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.PhotoAggregate.CombinationPhotos.Queries
{
    public class CombinationPhotoQueryService : ICombinationPhotoQueryService
    {
        private readonly IReadDbRepository<CombinationPhoto> _combinationPhotoRepository;

        public CombinationPhotoQueryService(IReadDbRepository<CombinationPhoto> combinationPhotoRepository)
        {
            _combinationPhotoRepository = combinationPhotoRepository;
        }

        /// <summary>
        /// GetAllCombinationPhotos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<CombinationPhoto>>> GetAllCombinationPhotos(GetAllCombinationPhotosReqModel request)
        {
            return Result.SuccessDataResult(await _combinationPhotoRepository.ToListAsync());
        }
    }
}
