using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductShipmentInfos;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductShipmentInfos;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductShipmentInfos
{
    public class ProductShipmentInfoService : IProductShipmentInfoService
    {
        #region Field
        private readonly IProductShipmentInfoDAL _productShipmentInfoDAL;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public ProductShipmentInfoService(IProductShipmentInfoDAL productShipmentInfoDAL, IUnitOfWork unitOfWork)
        {
            _productShipmentInfoDAL = productShipmentInfoDAL;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        #region Command
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
                var data= productShipmentInfo.MapTo<ProductShipmentInfo>();
                await _productShipmentInfoDAL.AddAsync(data);
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
                var data = await _productShipmentInfoDAL.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                var productShipment = request.MapTo(data);
                _productShipmentInfoDAL.Update(productShipment);
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
            if (productShipmentInfo.Id == 0)
            {
                return await AddProductShipmentInfo(productShipmentInfo.MapTo<AddProductShipmentInfoReqModel>());
            }
            else
            {
                return await UpdateProductShipmentInfo(productShipmentInfo.MapTo<UpdateProductShipmentInfoReqModel>());
            }
        }
        #endregion
        #region Query
        /// <summary>
        /// GetProductShipmentInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductShipmentInfo>> GetProductShipmentInfo(GetProductShipmentInfoReqModel request)
        {
            return Result.SuccessDataResult(await _productShipmentInfoDAL.GetAsync(x => x.ProductId == request.ProductId));
        }
        #endregion
        #endregion
    }
}
