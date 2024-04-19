using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductStocks.Queries
{
    public class ProductStockQueryService : IProductStockQueryService
    {
        private readonly IReadDbRepository<ProductStock> productStockRepository;

        public ProductStockQueryService(IReadDbRepository<ProductStock> productStockRepository)
        {
            this.productStockRepository = productStockRepository;
        }
        /// <summary>
        /// GetAllProductStock
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductStock>>> GetAllProductStock(GetAllProductStockReqModel request)
        {
            var data = await productStockRepository.Query().ApplyFilter(request)
                .ToPagedListAsync(request.PageIndex, request.PageSize);
            return Result.SuccessDataResult(data);
        }
    }
}
