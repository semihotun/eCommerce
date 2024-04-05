using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.PredefinedProductAttributeValues;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        #region Command
        /// <summary>
        /// InsertPredefinedProductAttributeValue
        /// </summary>
        /// <param name="ppav"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IPredefinedProductAttributeValue")]
        public async Task<Result<PredefinedProductAttributeValue>> InsertPredefinedProductAttributeValue(InsertPredefinedProductAttributeValueReqModel ppav)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = ppav.MapTo<PredefinedProductAttributeValue>();
                await _predefinedProductAttributeValueRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdatePredefinedProductAttributeValue
        /// </summary>
        /// <param name="ppav"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IPredefinedProductAttributeValue")]
        public async Task<Result> UpdatePredefinedProductAttributeValue(UpdatePredefinedProductAttributeValueReqModel ppav)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var predefinedProductAttributeValue = await _predefinedProductAttributeValueRepository.GetByIdAsync(ppav.Id);
                if(predefinedProductAttributeValue == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                var data = ppav.MapTo(predefinedProductAttributeValue);
                _predefinedProductAttributeValueRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// DeletePredefinedProductAttributeValue
        /// </summary>
        /// <param name="ppav"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IPredefinedProductAttributeValue")]
        public async Task<Result> DeletePredefinedProductAttributeValue(DeletePredefinedProductAttributeValueReqModel ppav)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _predefinedProductAttributeValueRepository.GetByIdAsync(ppav.Id);
                if (data == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                _predefinedProductAttributeValueRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetPredefinedProductAttributeValues
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public virtual async Task<Result<List<PredefinedProductAttributeValue>>> GetPredefinedProductAttributeValues(
            GetPredefinedProductAttributeValuesReqModel request)
        {
            return Result.SuccessDataResult(
                await (from ppav in _predefinedProductAttributeValueRepository.Query()
                       orderby ppav.DisplayOrder
                       where ppav.ProductAttributeId == request.ProductAttributeId
                       select ppav).ToListAsync());
        }
        /// <summary>
        /// GetPredefinedProductAttributeValueById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public virtual async Task<Result<PredefinedProductAttributeValue>> GetPredefinedProductAttributeValueById(
            GetPredefinedProductAttributeValueByIdReqModel request)
        {
            return Result.SuccessDataResult(
                await _predefinedProductAttributeValueRepository.GetAsync(x => x.Id == request.Id));
        }
        #endregion
        #endregion
    }
}
