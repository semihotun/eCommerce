using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Abstract.Discounts
{
    public interface IDiscountService
    {
        Task<IDataResult<Discount>> GetDiscount(int id);
        Task<IDataResult<IPagedList<Discount>>> GetAllList(int pageIndex=1,int pageSize=int.MaxValue);
        Task<IResult> UpdateDiscount(Discount discount);
        Task<IResult> AddDiscount(Discount discount);
        Task<IResult> DeleteDiscount(Discount discount);


    }
}
