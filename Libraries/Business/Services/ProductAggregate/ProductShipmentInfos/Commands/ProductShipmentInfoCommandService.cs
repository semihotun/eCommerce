using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ProductAggregate.ProductShipmentInfos;
using System.Threading.Tasks;
using System;
using DataAccess.UnitOfWork;
using DataAccess.Repository.Write;
using Business.Constants;
using Entities.Extensions.AutoMapper;

namespace Business.Services.ProductAggregate.ProductShipmentInfos.Commands
{
    public class ProductShipmentInfoCommandService : IProductShipmentInfoCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ProductShipmentInfo> _productShipmentInfoRepository;

        public ProductShipmentInfoCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<ProductShipmentInfo> productShipmentInfoRepository)
        {
            _unitOfWork = unitOfWork;
            _productShipmentInfoRepository = productShipmentInfoRepository;
        }

        /// <summary>
        /// AddProductShipmentInfo
        /// </summary>
        /// <param name="productShipmentInfo"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductShipmentInfo")]
        public async Task<Result<ProductShipmentInfo>> AddProductShipmentInfo(AddProductShipmentInfoReqModel productShipmentInfo)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = productShipmentInfo.MapTo<ProductShipmentInfo>();
                await _productShipmentInfoRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateProductShipmentInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductShipmentInfo")]
        public async Task<Result<ProductShipmentInfo>> UpdateProductShipmentInfo(UpdateProductShipmentInfoReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productShipmentInfoRepository.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                var productShipment = request.MapTo(data);
                _productShipmentInfoRepository.Update(productShipment);
                return Result.SuccessDataResult(productShipment);
            });
        }
        /// <summary>
        /// AddOrUpdateProductShipmentInfo
        /// </summary>
        /// <param name="productShipmentInfo"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductShipmentInfo")]
        public async Task<Result<ProductShipmentInfo>> AddOrUpdateProductShipmentInfo(AddOrUpdateProductShipmentInfoReqModel productShipmentInfo)
        {
            if (productShipmentInfo.Id == Guid.Empty)
            {
                return await AddProductShipmentInfo(productShipmentInfo.MapTo<AddProductShipmentInfoReqModel>());
            }
            else
            {
                return await UpdateProductShipmentInfo(productShipmentInfo.MapTo<UpdateProductShipmentInfoReqModel>());
            }
        }
    }
}
