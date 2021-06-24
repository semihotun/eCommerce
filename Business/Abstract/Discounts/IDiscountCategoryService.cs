using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Abstract.Discounts
{
    public interface IDiscountCategoryService
    {
        Task<IDataResult<IPagedList<DiscountCategory>>> GetAllDiscountCategory(int discountId = 0, int pageIndex = 1, int pageSize = int.MaxValue);
        Task<IResult> AddDiscountCategory(DiscountCategory discountCategory);
        Task<IResult> DeleteDiscountCategory(DiscountCategory discountCategory);
    }
}
