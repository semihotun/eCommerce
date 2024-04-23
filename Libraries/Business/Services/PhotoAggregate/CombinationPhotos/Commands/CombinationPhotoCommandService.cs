using Core.Const;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Secure;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.RequestModel.PhotoAggregate.CombinationPhotos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.PhotoAggregate.CombinationPhotos.Commands
{
    public class CombinationPhotoCommandService : ICombinationPhotoCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<CombinationPhoto> _combinationPhotoRepository;
        public CombinationPhotoCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<CombinationPhoto> combinationPhotoRepository)
        {
            _unitOfWork = unitOfWork;
            _combinationPhotoRepository = combinationPhotoRepository;
        }
        /// <summary>
        /// InsertCombinationPhotos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ICombination")]
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result> InsertCombinationPhotos(InsertCombinationPhotosReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var combinationData = new List<string>();
                if (request.Combinations != null)
                {
                    foreach (var item in request.Combinations.Split(',').ToList())
                    {
                        await _combinationPhotoRepository.AddAsync(new CombinationPhoto
                        {
                            PhotoId = request.PhotoId,
                            CombinationId = Guid.Parse(item)
                        });
                    }
                }
                if (request.NotCombinations != null)
                {
                    foreach (var item in request.NotCombinations.Split(','))
                    {
                        var removeData = await _combinationPhotoRepository.GetAsync(x => x.PhotoId == request.PhotoId
                            && x.CombinationId == Guid.Parse(item));
                        if (removeData != null)
                        {
                            _combinationPhotoRepository.Remove(removeData);
                        }
                    }
                }
                return Result.SuccessResult();
            });
        }
    }
}
