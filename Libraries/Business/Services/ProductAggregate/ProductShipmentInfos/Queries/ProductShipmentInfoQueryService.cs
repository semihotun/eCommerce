using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductShipmentInfos;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductShipmentInfos.Queries
{
    public class ProductShipmentInfoQueryService : IProductShipmentInfoQueryService
    {
        private readonly IReadDbRepository<ProductShipmentInfo> _productShipmentInfoRepository;

        public ProductShipmentInfoQueryService(IReadDbRepository<ProductShipmentInfo> productShipmentInfoRepository)
        {
            _productShipmentInfoRepository = productShipmentInfoRepository;
        }

        /// <summary>
        /// GetProductShipmentInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductShipmentInfo>> GetProductShipmentInfo(GetProductShipmentInfoReqModel request)
        {
            return Result.SuccessDataResult(await _productShipmentInfoRepository.GetAsync(x => x.ProductId == request.ProductId));
        }
    }
}
