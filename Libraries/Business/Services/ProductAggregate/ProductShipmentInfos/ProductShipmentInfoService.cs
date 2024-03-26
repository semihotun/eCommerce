using Business.Services.ProductAggregate.ProductShipmentInfos.ProductShipmentInfoServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductShipmentInfos;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Helpers.AutoMapper;
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
        [CacheAspect]
        public async Task<Result<ProductShipmentInfo>> GetProductShipmentInfo(GetProductShipmentInfo request)
        {
            return Result.SuccessDataResult<ProductShipmentInfo>(await _productShipmentInfoDAL.GetAsync(x => x.ProductId == request.ProductId));
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<Result> AddProductShipmentInfo(ProductShipmentInfo productShipmentInfo)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                await _productShipmentInfoDAL.AddAsync(productShipmentInfo);
                await Task.CompletedTask;
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<Result> UpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                var query = await _productShipmentInfoDAL.GetAsync(x => x.Id == productShipmentInfo.Id);
                var data = query.MapTo<ProductShipmentInfo>(productShipmentInfo);
                _productShipmentInfoDAL.Update(data);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<Result> AddOrUpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo)
        {
            if (productShipmentInfo.Id == 0)
                await AddProductShipmentInfo(productShipmentInfo);
            else
                await UpdateProductShipmentInfo(productShipmentInfo);
            return Result.SuccessResult();
        }
    }
}
