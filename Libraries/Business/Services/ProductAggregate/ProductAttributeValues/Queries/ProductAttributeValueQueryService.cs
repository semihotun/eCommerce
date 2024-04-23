using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeValues.Queries
{
    public class ProductAttributeValueQueryService : IProductAttributeValueQueryService
    {
        private readonly IReadDbRepository<ProductAttributeValue> _productAttributeValueRepository;
        public ProductAttributeValueQueryService(IReadDbRepository<ProductAttributeValue> productAttributeValueRepository)
        {
            _productAttributeValueRepository = productAttributeValueRepository;
        }
        /// <summary>
        /// GetProductAttributeValueById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductAttributeValue>> GetProductAttributeValueById(GetProductAttributeValueByIdReqModel request)
        {
            return Result.SuccessDataResult(await _productAttributeValueRepository.GetAsync(x => x.Id == request.ProductAttributeValueId));
        }
        /// <summary>
        /// GetProductAttributeValues
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<ProductAttributeValue>>> GetProductAttributeValues(GetProductAttributeValuesReqModel request)
        {
            var data = await (from pav in _productAttributeValueRepository.Query()
                              orderby pav.DisplayOrder, pav.Id
                              where pav.ProductAttributeMappingId == request.ProductAttributeMappingId
                              select pav).ToListAsync();
            return Result.SuccessDataResult(data);
        }
    }
}
