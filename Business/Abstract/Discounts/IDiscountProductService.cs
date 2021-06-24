using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Abstract.Discounts
{
    public interface IDiscountProductService
    {
        Task<IDataResult<IPagedList<DiscountProduct>>> GetAllDiscountProduct(int discountId = 0, int pageindex = 1, int pagesize = int.MaxValue);
        Task<IResult> AddDiscountProduct(DiscountProduct discountProduct);
        Task<IResult> DeleteDiscountProduct(DiscountProduct discountProduct);
    }
}
