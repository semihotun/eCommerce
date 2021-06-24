using Business.Abstract.Discounts;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Concrete.Discounts
{
    public class DiscountCategoryService : IDiscountCategoryService
    {
        #region Field
        private readonly IDiscountCategoryDAL _discountCategoryRepository;
        #endregion
        #region Ctor
        public DiscountCategoryService(IDiscountCategoryDAL discountCategoryRepository)
        {
            this._discountCategoryRepository = discountCategoryRepository;
        }
        #endregion
        #region Method
        public async Task<IResult> DeleteDiscountCategory(DiscountCategory discountCategory)
        {
            if (discountCategory == null)
                return new ErrorResult();

            _discountCategoryRepository.Delete(discountCategory);
            await _discountCategoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        public async Task<IDataResult<IPagedList<DiscountCategory>>> GetAllDiscountCategory(int discountId = 0,
          int pageindex = 1,int pageSize = int.MaxValue)
        {
            var query = _discountCategoryRepository.Query();

            if (discountId != 0)
                query = query.Where(x => x.DiscountId == discountId);

            var data = await query.ToPagedListAsync(pageindex,pageSize);

            return new SuccessDataResult<IPagedList<DiscountCategory>>(data);
        }
        public async Task<IResult> AddDiscountCategory(DiscountCategory discountCategory)
        {
            if (discountCategory == null)
                return new ErrorResult();

            _discountCategoryRepository.Add(discountCategory);
            await _discountCategoryRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion

    }
}
