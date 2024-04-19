using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.Read;
namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues.Queries
{
    public class PredefinedProductAttributeValueQueryService : IPredefinedProductAttributeValueQueryService
    {
        private readonly IReadDbRepository<PredefinedProductAttributeValue> _predefinedProductAttributeValueRepository;

        public PredefinedProductAttributeValueQueryService(IReadDbRepository<PredefinedProductAttributeValue> predefinedProductAttributeValueRepository)
        {
            _predefinedProductAttributeValueRepository = predefinedProductAttributeValueRepository;
        }

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
    }
}
