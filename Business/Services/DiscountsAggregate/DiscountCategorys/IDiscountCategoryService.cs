using Business.Services.DiscountsAggregate.DiscountCategorys.DiscountCategoryServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.DiscountsAggregate;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Services.DiscountsAggregate.DiscountCategorys
{
    public interface IDiscountCategoryService
    {
        Task<IDataResult<IPagedList<DiscountCategory>>> GetAllDiscountCategory(GetAllDiscountCategory request);
        Task<IResult> AddDiscountCategory(DiscountCategory discountCategory);
        Task<IResult> DeleteDiscountCategory(DiscountCategory discountCategory);
    }
}
