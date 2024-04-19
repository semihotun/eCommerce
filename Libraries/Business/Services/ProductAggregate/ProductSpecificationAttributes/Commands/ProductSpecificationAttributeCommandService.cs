using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.Commands
{
    public class ProductSpecificationAttributeCommandService : IProductSpecificationAttributeCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ProductSpecificationAttribute> _productSpecificationAttributeRepository;
        public ProductSpecificationAttributeCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<ProductSpecificationAttribute> productSpecificationAttributeRepository)
        {
            _unitOfWork = unitOfWork;
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
        }
        /// <summary>
        /// DeleteProductSpecificationAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductShipmentInfo")]
        public async Task<Result> DeleteProductSpecificationAttribute(DeleteProductSpecificationAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productSpecificationAttributeRepository.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                _productSpecificationAttributeRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertProductSpecificationAttribute
        /// </summary>
        /// <param name="productSpecificationAttribute"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductShipmentInfo")]
        public async Task<Result<ProductSpecificationAttribute>> InsertProductSpecificationAttribute(InsertProductSpecificationAttributeReqModel productSpecificationAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = productSpecificationAttribute.MapTo<ProductSpecificationAttribute>();
                await _productSpecificationAttributeRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateProductSpecificationAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductShipmentInfo")]
        public async Task<Result> UpdateProductSpecificationAttribute(UpdateProductSpecificationAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productSpecificationAttributeRepository.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                var productSpecificationAttribute = request.MapTo(data);
                _productSpecificationAttributeRepository.Update(productSpecificationAttribute);
                return Result.SuccessResult();
            });
        }
    }
}
