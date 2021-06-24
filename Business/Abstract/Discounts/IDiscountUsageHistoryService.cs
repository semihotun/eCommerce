using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Abstract.Discounts
{
    public interface IDiscountUsageHistoryService
    {
        Task<IDataResult<IPagedList<DiscountUsageHistory>>> GetAllDiscountUsageHistory(int discountId = 0, int pageIndex = 1, int pageSize = int.MaxValue);
        Task<IResult> AddDiscountUsageHistory(DiscountUsageHistory discountUsageHistory);
        Task<IResult> DeleteDiscountUsageHistory(DiscountUsageHistory discountUsageHistory);
        Task<IResult> UpdateDiscountUsageHistory(DiscountUsageHistory discountUsageHistory);
    }
}
