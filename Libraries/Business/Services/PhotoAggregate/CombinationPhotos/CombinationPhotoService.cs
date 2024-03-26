using Business.Services.PhotoAggregate.CombinationPhotos.CombinationPhotoServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos;
using DataAccess.UnitOfWork;
using Entities.Concrete.PhotoAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.PhotoAggregate.CombinationPhotos
{
    public class CombinationPhotoService : ICombinationPhotoService
    {
        #region Field
        private readonly ICombinationPhotoDAL _combinationPhotoRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public CombinationPhotoService(
            ICombinationPhotoDAL combinationPhotoRepository, IUnitOfWork unitOfWork)
        {
            _combinationPhotoRepository = combinationPhotoRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        [CacheAspect]
        public async Task<Result<List<CombinationPhoto>>> GetAllCombinationPhotos(GetAllCombinationPhotos request)
        {
            return Result.SuccessDataResult(await _combinationPhotoRepository.Query().ToListAsync());
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICombinationPhotoService.Get")]
        public async Task<Result> InsertCombinationPhotos(InsertCombinationPhotos request)
        {
            return await _unitOfWork.BeginTransaction(async() =>
            {
                var combinationData = new List<string>();
                if (request.Combinations != null)
                {
                    foreach (var item in request.Combinations.Split(',').ToList())
                    {
                        await _combinationPhotoRepository.AddAsync(new CombinationPhoto
                        {
                            PhotoId = request.PhotoId,
                            CombinationId = int.Parse(item)
                        });
                    }
                }
                if (request.NotCombinations != null)
                {
                    foreach (var item in request.NotCombinations.Split(','))
                    {
                        var removeData = await _combinationPhotoRepository.GetAsync(x => x.PhotoId == request.PhotoId
                            && x.CombinationId == int.Parse(item));
                        if(removeData != null)
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
