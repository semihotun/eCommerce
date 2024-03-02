using Business.Services.DiscountsAggregate.DiscountBrands.DiscountBrandServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountBrands;
using Entities.Concrete.DiscountsAggregate;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.DiscountsAggregate.DiscountBrands
{
    public class DiscountBrandService : IDiscountBrandService
    {
        #region Field
        private readonly IDiscountBrandDAL _discountBrandRepository;
        #endregion
        #region Ctor
        public DiscountBrandService(IDiscountBrandDAL discountBrandRepository)
        {
            _discountBrandRepository = discountBrandRepository;
        }
        #endregion
        #region Method
        [CacheRemoveAspect("IDiscountBrandService.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> DeleteDiscountBrand(DiscountBrand discountBrand)
        {
            _discountBrandRepository.Delete(discountBrand);
            await _discountBrandRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<DiscountBrand>>> GetAllDiscountBrand(GetAllDiscountBrand request)
        {
            var query = _discountBrandRepository.Query();
            if (request.DiscountId != 0)
                query = query.Where(x => x.DiscountId == request.DiscountId);
            var data = await query.ToPagedListAsync(request.Pageindex, request.PageSize);
            return new SuccessDataResult<IPagedList<DiscountBrand>>(data);
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IDiscountBrandService.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> AddDiscountBrand(DiscountBrand discountBrand)
        {
            if (discountBrand == null)
                return new ErrorResult();
            _discountBrandRepository.Add(discountBrand);
            await _discountBrandRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
    }
}
