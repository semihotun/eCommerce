using Business.Services.DiscountsAggregate.DiscountProducts.DiscountProductServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountProducts;
using Entities.Concrete.DiscountsAggregate;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Services.DiscountsAggregate.DiscountProducts
{
    public class DiscountProductService : IDiscountProductService
    {
        #region Field
        private readonly DiscountProductDAL _discountProductRepository;
        #endregion

        #region Ctor
        public DiscountProductService(DiscountProductDAL discountProductRepository)
        {
            _discountProductRepository = discountProductRepository;
        }
        #endregion

        #region Method
        [CacheRemoveAspect("IDiscountProductService.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> DeleteDiscountProduct(DiscountProduct discountProduct)
        {
            if (discountProduct == null)
                return new ErrorResult();

            _discountProductRepository.Delete(discountProduct);
            await _discountProductRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        [CacheRemoveAspect("IDiscountProductService.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> AddDiscountProduct(DiscountProduct discountProduct)
        {
            if (discountProduct == null)
                return new ErrorResult();

            _discountProductRepository.Add(discountProduct);
            await _discountProductRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        [CacheAspect]
        public async Task<IDataResult<IPagedList<DiscountProduct>>> GetAllDiscountProduct(
             GetAllDiscountProduct request)
        {
            var query = _discountProductRepository.Query();

            if (request.DiscountId != 0)
                query = query.Where(x => x.DiscountId == request.DiscountId);

            var data = await query.ToPagedListAsync(request.Pageindex, request.Pagesize);

            return new SuccessDataResult<IPagedList<DiscountProduct>>(data);
        }
        #endregion
    }
}
