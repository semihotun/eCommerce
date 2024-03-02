using Business.Services.DiscountsAggregate.DiscountCategorys.DiscountCategoryServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Nuget.X.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountCategorys;
using Entities.Concrete.DiscountsAggregate;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.DiscountsAggregate.DiscountCategorys
{
    public class DiscountCategoryService : IDiscountCategoryService
    {
        #region Field
        private readonly IDiscountCategoryDAL _discountCategoryRepository;
        #endregion
        #region Ctor
        public DiscountCategoryService(IDiscountCategoryDAL discountCategoryRepository)
        {
            _discountCategoryRepository = discountCategoryRepository;
        }
        #endregion
        #region Method
        [CacheRemoveAspect("IDiscountCategoryService.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> DeleteDiscountCategory(DiscountCategory discountCategory)
        {
            if (discountCategory == null)
                return new ErrorResult();
            _discountCategoryRepository.Delete(discountCategory);
            await _discountCategoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<DiscountCategory>>> GetAllDiscountCategory(GetAllDiscountCategory request)
        {
            var query = _discountCategoryRepository.Query();
            if (request.DiscountId != 0)
                query = query.Where(x => x.DiscountId == request.DiscountId);
            var data = await query.ToPagedListAsync(request.Pageindex, request.PageSize);
            return new SuccessDataResult<IPagedList<DiscountCategory>>(data);
        }
        [CacheRemoveAspect("IDiscountCategoryService.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> AddDiscountCategory(DiscountCategory discountCategory)
        {
            if (discountCategory == null)
                return new ErrorResult();
            _discountCategoryRepository.Add(discountCategory);
            await _discountCategoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
    }
}
