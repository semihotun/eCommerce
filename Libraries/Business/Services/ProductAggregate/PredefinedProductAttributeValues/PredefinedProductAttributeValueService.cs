using Business.Services.ProductAggregate.PredefinedProductAttributeValues.PredefinedProductAttributeValueServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.PredefinedProductAttributeValues;
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
        #endregion

        #region Ctor
        public PredefinedProductAttributeValueService(IPredefinedProductAttributeValueDAL predefinedProductAttributeValueRepository)
        {
            _predefinedProductAttributeValueRepository = predefinedProductAttributeValueRepository;
        }
        #endregion

        #region Method
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IPredefinedProductAttributeValueService.Get")]
        public virtual async Task<IResult> DeletePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            if (ppav == null)
                return new ErrorResult();

            _predefinedProductAttributeValueRepository.Delete(ppav);
            await _predefinedProductAttributeValueRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        [CacheAspect]
        public virtual async Task<IDataResult<IList<PredefinedProductAttributeValue>>> GetPredefinedProductAttributeValues(
            GetPredefinedProductAttributeValues request)
        {
            var query = from ppav in _predefinedProductAttributeValueRepository.Query()
                        orderby ppav.DisplayOrder
                        where ppav.ProductAttributeId == request.ProductAttributeId
                        select ppav;

            var data = await query.ToListAsync();

            return new SuccessDataResult<List<PredefinedProductAttributeValue>>(data);
        }

        [CacheAspect]
        public virtual async Task<IDataResult<PredefinedProductAttributeValue>> GetPredefinedProductAttributeValueById(
            GetPredefinedProductAttributeValueById request)
        {
            var data = await _predefinedProductAttributeValueRepository.GetAsync(x => x.Id == request.Id);

            return new SuccessDataResult<PredefinedProductAttributeValue>(data);
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IPredefinedProductAttributeValueService.Get")]
        public virtual async Task<IResult> InsertPredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            if (ppav == null)
                return new ErrorResult();

            _predefinedProductAttributeValueRepository.Add(ppav);
            await _predefinedProductAttributeValueRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IPredefinedProductAttributeValueService.Get")]
        public virtual async Task<IResult> UpdatePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            if (ppav == null)
                return new ErrorResult();

            _predefinedProductAttributeValueRepository.Update(ppav);
            await _predefinedProductAttributeValueRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        #endregion
    }
}
