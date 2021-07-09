using AutoMapper;
using Business.Abstract.Discounts;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Threading.Tasks;
using X.PagedList;


namespace Business.Concrete.Discounts
{
    public class DiscountService : IDiscountService
    {

        private readonly IDiscountDAL _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(
            IDiscountDAL discountRepository,
            IMapper mapper
            )
        {
            this._discountRepository = discountRepository;
            this._mapper = mapper;
        }
        [CacheAspect]
        public async Task<IDataResult<Discount>> GetDiscount(int id)
        {
            if (id == 0)
                return new ErrorDataResult<Discount>();

            var data = await _discountRepository.GetAsync(x=>x.Id==id);

            return new SuccessDataResult<Discount>(data);
        }
        [CacheRemoveAspect("IDiscountService.Get")]
        public async Task<IResult> AddDiscount(Discount discount)
        {
            if (discount == null)
                return new ErrorResult();

            _discountRepository.Add(discount);
            await _discountRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheRemoveAspect("IDiscountService.Get")]
        public async Task<IResult> DeleteDiscount(Discount discount)
        {
            if (discount == null)
                return new ErrorResult();

            _discountRepository.Delete(discount);
            await _discountRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<Discount>>> GetAllList(int pageIndex = 1, int pageSize = int.MaxValue)
        {
            var query = _discountRepository.Query();

            var data = await query.ToPagedListAsync(pageIndex, pageSize);

            return new SuccessDataResult<IPagedList<Discount>>(data);
        }
        [CacheRemoveAspect("IDiscountService.Get")]
        public async Task<IResult> UpdateDiscount(Discount discount)
        {
            if (discount == null)
                return new ErrorResult();

            var data =await _discountRepository.GetAsync(x => x.Id==discount.Id);
            data = _mapper.Map(discount, data);

            _discountRepository.Update(data);
            await _discountRepository.SaveChangesAsync();

            return new SuccessResult();
        }

    }
}
