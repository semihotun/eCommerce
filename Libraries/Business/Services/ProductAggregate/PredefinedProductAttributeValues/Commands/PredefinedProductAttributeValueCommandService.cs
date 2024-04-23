using Business.Constants;
using Core.Const;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Secure;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues.Commands
{
    public class PredefinedProductAttributeValueCommandService : IPredefinedProductAttributeValueCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<PredefinedProductAttributeValue> _predefinedProductAttributeValueRepository;

        public PredefinedProductAttributeValueCommandService(IUnitOfWork unitOfWork,
            IWriteDbRepository<PredefinedProductAttributeValue> predefinedProductAttributeValueRepository)
        {
            _unitOfWork = unitOfWork;
            _predefinedProductAttributeValueRepository = predefinedProductAttributeValueRepository;
        }

        /// <summary>
        /// InsertPredefinedProductAttributeValue
        /// </summary>
        /// <param name="ppav"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IPredefinedProductAttributeValue")]
        [AuthAspect(RoleConst.Admin)]
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
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result> UpdatePredefinedProductAttributeValue(UpdatePredefinedProductAttributeValueReqModel ppav)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var predefinedProductAttributeValue = await _predefinedProductAttributeValueRepository.GetByIdAsync(ppav.Id);
                if (predefinedProductAttributeValue == null)
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
        [AuthAspect(RoleConst.Admin)]
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
    }
}
