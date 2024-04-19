using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.Products;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.Products.Queries
{
    public class ProductQueryService : IProductQueryService
    {
        private readonly IReadDbRepository<Product> _productRepository;
        private readonly IReadDbRepository<ProductSpecificationAttribute> _productSpecificationAttributeRepository;
        private readonly IReadDbRepository<SpecificationAttributeOption> _specificationAttributeOptionRepository;

        public ProductQueryService(IReadDbRepository<Product> productRepository,
            IReadDbRepository<ProductSpecificationAttribute> productSpecificationAttributeRepository,
            IReadDbRepository<SpecificationAttributeOption> specificationAttributeOptionRepository)
        {
            _productRepository = productRepository;
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
        }

        /// <summary>
        /// GetProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<Product>> GetProduct(GetProductReqModel request)
        {
            return Result.SuccessDataResult(await _productRepository.GetAsync(x => x.Id == request.Id));
        }
        /// <summary>
        /// GetProductsBySpecificationAttributeId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<Product>>> GetProductsBySpecificationAttributeId(
            GetProductsBySpecificationAttributeIdReqModel request)
        {
            var query = from product in _productRepository.Query()
                        join psa in _productSpecificationAttributeRepository.Query() on product.Id equals psa.ProductId
                        join spao in _specificationAttributeOptionRepository.Query() on psa.SpecificationAttributeOptionId equals spao.Id
                        where spao.SpecificationAttributeId == request.SpecificationAttributeId
                        orderby product.ProductName
                        select product;
            return Result.SuccessDataResult(await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
    }
}
