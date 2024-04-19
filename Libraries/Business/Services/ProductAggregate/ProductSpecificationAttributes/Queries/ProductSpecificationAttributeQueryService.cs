using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.Read;
namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.Queries
{
    public class ProductSpecificationAttributeQueryService : IProductSpecificationAttributeQueryService
    {
        private readonly IReadDbRepository<ProductSpecificationAttribute> _productSpecificationAttributeRepository;

        public ProductSpecificationAttributeQueryService(IReadDbRepository<ProductSpecificationAttribute> productSpecificationAttributeRepository)
        {
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
        }

        /// <summary>
        /// GetProductSpecificationAttributes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductSpecificationAttribute>>> GetProductSpecificationAttributes(
            GetProductSpecificationAttributesReqModel request)
        {
            var query = _productSpecificationAttributeRepository.Query();
            if (request.ProductId != Guid.Empty)
                query = query.Where(psa => psa.ProductId == request.ProductId);
            if (request.SpecificationAttributeOptionId != Guid.Empty)
                query = query.Where(psa => psa.SpecificationAttributeOptionId == request.SpecificationAttributeOptionId);
            if (request.AllowFiltering.HasValue)
                query = query.Where(psa => psa.AllowFiltering == request.AllowFiltering.Value);
            if (request.ShowOnProductPage.HasValue)
                query = query.Where(psa => psa.ShowOnProductPage == request.ShowOnProductPage.Value);
            query = query.OrderBy(psa => psa.DisplayOrder).ThenBy(psa => psa.Id);
            return Result.SuccessDataResult(
                await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        /// <summary>
        /// GetProductSpecificationAttributeById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductSpecificationAttribute>> GetProductSpecificationAttributeById(GetProductSpecificationAttributeByIdReqModel request)
        {
            var data = await _productSpecificationAttributeRepository.GetByIdAsync(request.ProductSpecificationAttributeId);
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// GetProductSpecificationAttributeCount
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<int>> GetProductSpecificationAttributeCount(GetProductSpecificationAttributeCountReqModel request)
        {
            var query = _productSpecificationAttributeRepository.Query();
            if (request.ProductId != Guid.Empty)
                query = query.Where(psa => psa.ProductId == request.ProductId);
            if (request.SpecificationAttributeOptionId != Guid.Empty)
                query = query.Where(psa => psa.SpecificationAttributeOptionId == request.SpecificationAttributeOptionId);
            var data = await query.CountAsync();
            return Result.SuccessDataResult(data);
        }
    }
}
