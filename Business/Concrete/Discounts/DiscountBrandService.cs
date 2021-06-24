using Business.Abstract;
using Business.Abstract.Discounts;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Concrete.Discounts
{
    public class DiscountBrandService : IDiscountBrandService
    {
        #region Field
        private readonly IDiscountBrandDAL _discountBrandRepository;
        #endregion
        #region Ctor
        public DiscountBrandService(IDiscountBrandDAL discountBrandRepository)
        {
            this._discountBrandRepository = discountBrandRepository;
        }
        #endregion
        #region Method
        public async Task<IResult> DeleteDiscountBrand(DiscountBrand discountBrand)
        {

            _discountBrandRepository.Delete(discountBrand);
            await _discountBrandRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        public async Task<IDataResult<IPagedList<DiscountBrand>>> GetAllDiscountBrand(int discountId = 0,
        int pageindex = 1, int pageSize = int.MaxValue)
        {
            var query = _discountBrandRepository.Query();

            if (discountId != 0)
                query = query.Where(x => x.DiscountId == discountId);

            var data = await query.ToPagedListAsync(pageindex, pageSize);

            return new SuccessDataResult<IPagedList<DiscountBrand>>(data);
        }

        public async Task<IResult> AddDiscountBrand(DiscountBrand discountBrand)
        {
            if (discountBrand == null)
                return new ErrorResult();

            _discountBrandRepository.Add(discountBrand);
            await _discountBrandRepository.SaveChangesAsync();

            return new SuccessResult();
        }
        #endregion
    }
}
