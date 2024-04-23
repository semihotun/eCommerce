using Business.Constants;
using Core.Const;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Secure;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributes;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductAttributes.Commands
{
    public class ProductAttributeCommandService : IProductAttributeCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ProductAttribute> _productAttributeRepository;
        public ProductAttributeCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<ProductAttribute> productAttributeRepository)
        {
            _unitOfWork = unitOfWork;
            _productAttributeRepository = productAttributeRepository;
        }
        /// <summary>
        /// DeleteProductAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttribute")]
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result> DeleteProductAttribute(DeleteProductAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productAttributeRepository.GetByIdAsync(request.Id);
                if (data == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                _productAttributeRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertProductAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttribute")]
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result<ProductAttribute>> InsertProductAttribute(InsertProductAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<ProductAttribute>();
                await _productAttributeRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateProductAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttribute")]
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result> UpdateProductAttribute(UpdateProductAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var productAttribute = await _productAttributeRepository.GetByIdAsync(request.Id);
                if (productAttribute == null)
                    Result.ErrorResult(Messages.IdNotFound);
                var data = request.MapTo(productAttribute);
                _productAttributeRepository.Update(data);
                return Result.SuccessResult();
            });
        }
    }
}
