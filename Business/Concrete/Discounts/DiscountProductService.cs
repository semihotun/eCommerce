using Business.Abstract.Discounts;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Concrete.Discounts
{
    public class DiscountProductService : IDiscountProductService
    {
        #region Field
        private readonly DiscountProductDAL _discountProductRepository;
        #endregion

        #region Ctor
        public DiscountProductService(DiscountProductDAL discountProductRepository)
        {
            this._discountProductRepository = discountProductRepository;
        }
        #endregion

        #region Method
        [CacheRemoveAspect("IDiscountProductService.Get")]
        public async Task<IResult> DeleteDiscountProduct(DiscountProduct discountProduct)
        {
            if (discountProduct == null)
                return new ErrorResult();

            _discountProductRepository.Delete(discountProduct);
            await _discountProductRepository.SaveChangesAsync();

            return new SuccessResult();
        }
        [CacheRemoveAspect("IDiscountProductService.Get")]
        public async Task<IResult> AddDiscountProduct(DiscountProduct discountProduct)
        {
            if (discountProduct == null)
                return new ErrorResult();

            _discountProductRepository.Add(discountProduct);
            await _discountProductRepository.SaveChangesAsync();

            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<DiscountProduct>>> GetAllDiscountProduct(int DiscountId = 0,
        int pageindex = 1, int pagesize = int.MaxValue)
        {
            var query = _discountProductRepository.Query();

            if (DiscountId != 0)
                query = query.Where(x => x.DiscountId == DiscountId);

            var data = await query.ToPagedListAsync(pageindex,pagesize);

            return new SuccessDataResult<IPagedList<DiscountProduct>>(data);
        }
        #endregion
    }
}
