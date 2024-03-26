using Business.Services.ProductAggregate.PredefinedProductAttributeValues.PredefinedProductAttributeValueServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.PredefinedProductAttributeValues;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues
{
    public class PredefinedProductAttributeValueService : IPredefinedProductAttributeValueService
    {
        #region Field
        private readonly IPredefinedProductAttributeValueDAL _predefinedProductAttributeValueRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public PredefinedProductAttributeValueService(IPredefinedProductAttributeValueDAL predefinedProductAttributeValueRepository, IUnitOfWork unitOfWork)
        {
            _predefinedProductAttributeValueRepository = predefinedProductAttributeValueRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IPredefinedProductAttributeValueService.Get")]
        public virtual async Task<Result> DeletePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                _predefinedProductAttributeValueRepository.Remove(ppav);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public virtual async Task<Result<List<PredefinedProductAttributeValue>>> GetPredefinedProductAttributeValues(
            GetPredefinedProductAttributeValues request)
        {
            return Result.SuccessDataResult(
                await (from ppav in _predefinedProductAttributeValueRepository.Query()
                       orderby ppav.DisplayOrder
                       where ppav.ProductAttributeId == request.ProductAttributeId
                       select ppav).ToListAsync());
        }
        [CacheAspect]
        public virtual async Task<Result<PredefinedProductAttributeValue>> GetPredefinedProductAttributeValueById(
            GetPredefinedProductAttributeValueById request)
        {
            return Result.SuccessDataResult(
                await _predefinedProductAttributeValueRepository.GetAsync(x => x.Id == request.Id));
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IPredefinedProductAttributeValueService.Get")]
        public virtual async Task<Result> InsertPredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                await _predefinedProductAttributeValueRepository.AddAsync(ppav);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IPredefinedProductAttributeValueService.Get")]
        public virtual async Task<Result> UpdatePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                _predefinedProductAttributeValueRepository.Update(ppav);
                return Result.ErrorResult();
            });
        }
        #endregion
    }
}
