using Business.Services.ProductAggregate.ProductShipmentInfos.ProductShipmentInfoServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductShipmentInfos;
using Entities.Concrete.ProductAggregate;
using Entities.Helpers.AutoMapper;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.ProductShipmentInfos
{
    public class ProductShipmentInfoService : IProductShipmentInfoService
    {
        #region Field
        private readonly IProductShipmentInfoDAL _productShipmentInfoDAL;

        #endregion
        #region Ctor
        public ProductShipmentInfoService(IProductShipmentInfoDAL productShipmentInfoDAL)
        {
            _productShipmentInfoDAL = productShipmentInfoDAL;
        }
        #endregion
        [CacheAspect]
        public async Task<IDataResult<ProductShipmentInfo>> GetProductShipmentInfo(GetProductShipmentInfo request)
        {
            var query = await _productShipmentInfoDAL.GetAsync(x => x.ProductId == request.ProductId);

            return new SuccessDataResult<ProductShipmentInfo>(query);
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<IResult> AddProductShipmentInfo(ProductShipmentInfo productShipmentInfo)
        {
            _productShipmentInfoDAL.Add(productShipmentInfo);
            await _productShipmentInfoDAL.SaveChangesAsync();

            return new SuccessResult();
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<IResult> UpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo)
        {
            var query = await _productShipmentInfoDAL.GetAsync(x => x.Id == productShipmentInfo.Id);
            var data = query.MapTo<ProductShipmentInfo>(productShipmentInfo);
            _productShipmentInfoDAL.Update(data);
            await _productShipmentInfoDAL.SaveChangesAsync();

            return new SuccessResult();
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IProductShipmentInfoService.Get")]
        public async Task<IResult> AddOrUpdateProductShipmentInfo(ProductShipmentInfo productShipmentInfo)
        {
            if (productShipmentInfo.Id == 0)
                await AddProductShipmentInfo(productShipmentInfo);
            else
                await UpdateProductShipmentInfo(productShipmentInfo);

            return new SuccessResult();
        }


    }
}
