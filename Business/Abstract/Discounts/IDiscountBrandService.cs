using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Abstract.Discounts
{
    public interface IDiscountBrandService
    {
        Task<IDataResult<IPagedList<DiscountBrand>>> GetAllDiscountBrand(int discountId = 0, int pageindex = 1,
            int pageSize = int.MaxValue);
        Task<IResult> AddDiscountBrand(DiscountBrand discountBrand);
        Task<IResult> DeleteDiscountBrand(DiscountBrand discountBrand);
    }
}
