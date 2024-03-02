using Business.Services.DiscountsAggregate.DiscountUsageHistorys.DiscountUsageHistoryServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountUsageHistorys;
using Entities.Concrete.DiscountsAggregate;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.DiscountsAggregate.DiscountUsageHistorys
{
    public class DiscountUsageHistoryService : IDiscountUsageHistoryService
    {
        #region Field
        private readonly IDiscountUsageHistoryDAL _discountUsageHistoryRepository;
        #endregion
        #region Ctor
        public DiscountUsageHistoryService(IDiscountUsageHistoryDAL discountUsageHistoryRepository)
        {
            _discountUsageHistoryRepository = discountUsageHistoryRepository;
        }
        #endregion
        #region Method
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IDiscountUsageHistoryService.Get", "IDiscountUsageHistoryDAL.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> AddDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            if (discountUsageHistory == null)
                return new ErrorResult();
            _discountUsageHistoryRepository.Add(discountUsageHistory);
            await _discountUsageHistoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IDiscountUsageHistoryService.Get,IDiscountUsageHistoryDAL.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> DeleteDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            if (discountUsageHistory == null)
                return new ErrorResult();
            _discountUsageHistoryRepository.Delete(discountUsageHistory);
            await _discountUsageHistoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<DiscountUsageHistory>>> GetAllDiscountUsageHistory(
            GetAllDiscountUsageHistory request)
        {
            var query = _discountUsageHistoryRepository.Query();
            if (request.DiscountId != 0)
                query = query.Where(x => x.DiscountId == request.DiscountId);
            var data = await query.ToPagedListAsync(request.Pageindex, request.Pagesize);
            return new SuccessDataResult<IPagedList<DiscountUsageHistory>>(data);
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IDiscountUsageHistoryService.Get,IDiscountUsageHistoryDAL.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> UpdateDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            if (discountUsageHistory == null)
                return new ErrorResult();
            _discountUsageHistoryRepository.Update(discountUsageHistory);
            await _discountUsageHistoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
    }
}
