using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeCombinations.Queries
{
    public class ProductAttributeCombinationQueryService : IProductAttributeCombinationQueryService
    {
        private IReadDbRepository<ProductAttributeCombination> _productAttributeCombinationRepository;

        public ProductAttributeCombinationQueryService(IReadDbRepository<ProductAttributeCombination> productAttributeCombinationRepository)
        {
            _productAttributeCombinationRepository = productAttributeCombinationRepository;
        }

        /// <summary>
        /// GetAllProductAttributeCombinations
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(GetAllProductAttributeCombinationsReqModel request)
        {
            var query = from pac in _productAttributeCombinationRepository.Query()
                        where pac.ProductId == request.ProductId
                        select pac;
            if (request.Orderbytext != null)
                query = query.OrderBy(request.Orderbytext);
            return Result.SuccessDataResult(await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        /// <summary>
        /// GetProductCombinationXml
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<string>>> GetProductCombinationXml(GetProductCombinationXmlReqModel request)
        {
            var query = from c in _productAttributeCombinationRepository.Query()
                        orderby c.Id
                        where c.ProductId == request.ProductId
                        select c.AttributesXml;
            return Result.SuccessDataResult(await query.ToListAsync());
        }
        /// <summary>
        /// GetProductAttributeCombinationById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationById(GetProductAttributeCombinationByIdReqModel request)
        {
            var data = await _productAttributeCombinationRepository
                .GetAsync(x => x.Id == request.ProductAttributeCombinationId);
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// GetProductAttributeCombinationBySku
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationBySku(GetProductAttributeCombinationBySkuReqModel request)
        {
            var data = await (from pac in _productAttributeCombinationRepository.Query()
                              orderby pac.Id
                              where pac.Sku == request.Sku.Trim()
                              select pac).FirstOrDefaultAsync();
            return Result.SuccessDataResult(data);
        }
    }
}
