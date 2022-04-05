using Business.Services.DiscountsAggregate.Discounts.DiscountServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.DiscountsAggregate;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Services.DiscountsAggregate.Discounts
{
    public interface IDiscountService
    {
        Task<IDataResult<Discount>> GetDiscount(GetDiscount request);
        Task<IDataResult<IPagedList<Discount>>> GetAllList(GetAllList request);
        Task<IResult> UpdateDiscount(Discount discount);
        Task<IResult> AddDiscount(Discount discount);
        Task<IResult> DeleteDiscount(Discount discount);


    }
}
