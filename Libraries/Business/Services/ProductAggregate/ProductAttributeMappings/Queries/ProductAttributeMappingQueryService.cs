using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeMappings.Queries
{
    public class ProductAttributeMappingQueryService : IProductAttributeMappingQueryService
    {
        private readonly IReadDbRepository<ProductAttributeMapping> _productAttributeMappingRepository;

        public ProductAttributeMappingQueryService(IReadDbRepository<ProductAttributeMapping> productAttributeMappingRepository)
        {
            _productAttributeMappingRepository = productAttributeMappingRepository;
        }

        /// <summary>
        /// GetAllProductAttributeMapping
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductAttributeMapping>>> GetAllProductAttributeMapping(GetAllProductAttributeMappingReqModel request)
        {
            return Result.SuccessDataResult(
                await (from pam in _productAttributeMappingRepository.Query()
                       orderby pam.DisplayOrder, pam.Id
                       where pam.ProductId == request.ProductId
                       select pam).ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        /// <summary>
        /// GetProductAttributeMappingsByProductId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<ProductAttributeMapping>>> GetProductAttributeMappingsByProductId(GetProductAttributeMappingsByProductIdReqModel request)
        {
            var query = from pam in _productAttributeMappingRepository.Query()
                        orderby pam.DisplayOrder, pam.Id
                        where pam.ProductId == request.ProductId
                        select pam;
            return Result.SuccessDataResult(await query.ToListAsync());
        }
        /// <summary>
        /// GetProductAttributeMappingById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeMapping")]
        public async Task<Result<ProductAttributeMapping>> GetProductAttributeMappingById(GetProductAttributeMappingByIdReqModel request)
        {
            return Result.SuccessDataResult(
                await _productAttributeMappingRepository.GetAsync(x => x.Id == request.ProductAttributeMappingId));
        }
    }
}
