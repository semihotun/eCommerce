using Business.Services.DiscountsAggregate.DiscountUsageHistorys.DiscountUsageHistoryServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.DiscountsAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.DiscountsAggregate.DiscountUsageHistorys
{
    public interface IDiscountUsageHistoryService
    {
        Task<IDataResult<IPagedList<DiscountUsageHistory>>> GetAllDiscountUsageHistory(GetAllDiscountUsageHistory request);
        Task<IResult> AddDiscountUsageHistory(DiscountUsageHistory discountUsageHistory);
        Task<IResult> DeleteDiscountUsageHistory(DiscountUsageHistory discountUsageHistory);
        Task<IResult> UpdateDiscountUsageHistory(DiscountUsageHistory discountUsageHistory);
    }
}
