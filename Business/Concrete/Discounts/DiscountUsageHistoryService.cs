using Business.Abstract.Discounts;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Concrete.Discounts
{
    public class DiscountUsageHistoryService : IDiscountUsageHistoryService
    {
        #region Field
        private readonly IDiscountUsageHistoryDAL _discountUsageHistoryRepository;
        #endregion
        #region Ctor
        public DiscountUsageHistoryService(IDiscountUsageHistoryDAL discountUsageHistoryRepository)
        {
            this._discountUsageHistoryRepository = discountUsageHistoryRepository;
        }
        #endregion
        #region Method
        [CacheRemoveAspect("IDiscountUsageHistoryService.Get")]
        public async Task<IResult> AddDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            if (discountUsageHistory == null)
                return new ErrorResult();

            _discountUsageHistoryRepository.Add(discountUsageHistory);
            await _discountUsageHistoryRepository.SaveChangesAsync();

            return new SuccessResult();
        }
        [CacheRemoveAspect("IDiscountUsageHistoryService.Get")]
        public async Task<IResult> DeleteDiscountUsageHistory(DiscountUsageHistory discountUsageHistory)
        {
            if (discountUsageHistory == null)
                return new ErrorResult();

            _discountUsageHistoryRepository.Delete(discountUsageHistory);
            await _discountUsageHistoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<DiscountUsageHistory>>> GetAllDiscountUsageHistory(int discountId = 0,
             int pageindex = 1, int pagesize = int.MaxValue)
        {
            var query = _discountUsageHistoryRepository.Query();

            if (discountId != 0)
                query = query.Where(x => x.DiscountId == discountId);

            var data = await query.ToPagedListAsync(pageindex, pagesize);

            return new SuccessDataResult<IPagedList<DiscountUsageHistory>>(data);
        }
        [CacheRemoveAspect("IDiscountUsageHistoryService.Get")]
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
