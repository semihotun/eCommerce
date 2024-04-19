using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributeMappings.Commands
{
    public class ProductAttributeMappingCommandService : IProductAttributeMappingCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ProductAttributeMapping> _productAttributeMappingRepository;
        private readonly IWriteDbRepository<ProductAttributeValue> _productAttributeValueRepository;

        public ProductAttributeMappingCommandService(IUnitOfWork unitOfWork,
            IWriteDbRepository<ProductAttributeMapping> productAttributeMappingRepository,
            IWriteDbRepository<ProductAttributeValue> productAttributeValueRepository)
        {
            _unitOfWork = unitOfWork;
            _productAttributeMappingRepository = productAttributeMappingRepository;
            _productAttributeValueRepository = productAttributeValueRepository;
        }

        /// <summary>
        /// InsertProductAttributeMapping
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeMapping")]
        public async Task<Result<ProductAttributeMapping>> InsertProductAttributeMapping(InsertProductAttributeMappingReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<ProductAttributeMapping>();
                await _productAttributeMappingRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateProductAttributeMapping
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeMapping")]
        public async Task<Result> UpdateProductAttributeMapping(UpdateProductAttributeMappingReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var productAttributeMapping = await _productAttributeMappingRepository.GetByIdAsync(request.Id);
                if (productAttributeMapping == null)
                    return Result.ErrorResult();
                var data = request.MapTo(productAttributeMapping);
                _productAttributeMappingRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// DeleteProductAttributeMapping
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeMapping")]
        public async Task<Result> DeleteProductAttributeMapping(DeleteProductAttributeMappingReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productAttributeMappingRepository.GetByIdAsync(request.Id);
                if (data == null)
                    return Result.ErrorResult();
                var productAttributeValues = await _productAttributeValueRepository.ToListAsync(x => x.ProductAttributeMappingId == request.Id);
                foreach (var item in productAttributeValues)
                {
                    var productAttributeData = await _productAttributeValueRepository.GetByIdAsync( item.Id);
                    if (productAttributeData != null)
                    {
                        _productAttributeValueRepository.Remove(productAttributeData);
                    }
                }
                _productAttributeMappingRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
    }
}
