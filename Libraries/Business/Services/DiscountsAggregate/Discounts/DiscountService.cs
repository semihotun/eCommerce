using AutoMapper;
using Business.Services.DiscountsAggregate.Discounts.DiscountServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts;
using Entities.Concrete.DiscountsAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.DiscountsAggregate.Discounts
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
            _discountRepository = discountRepository;
            _mapper = mapper;
        }
        [CacheAspect]
        public async Task<IDataResult<Discount>> GetDiscount(GetDiscount request)
        {
            if (request.Id == 0)
                return new ErrorDataResult<Discount>();
            var data = await _discountRepository.GetAsync(x => x.Id == request.Id);
            return new SuccessDataResult<Discount>(data);
        }
        [CacheRemoveAspect("IDiscountService.Get,IDiscountDAL.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> AddDiscount(Discount discount)
        {
            if (discount == null)
                return new ErrorResult();
            _discountRepository.Add(discount);
            await _discountRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheRemoveAspect("IDiscountService.Get,IDiscountDAL.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<IResult> DeleteDiscount(Discount discount)
        {
            if (discount == null)
                return new ErrorResult();
            _discountRepository.Delete(discount);
            await _discountRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<Discount>>> GetAllList(GetAllList request)
        {
            var query = _discountRepository.Query();
            var data = await query.ToPagedListAsync(request.PageIndex, request.PageSize);
            return new SuccessDataResult<IPagedList<Discount>>(data);
        }
        [CacheRemoveAspect("IDiscountService.Get,IDiscountDAL.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> UpdateDiscount(Discount discount)
        {
            if (discount == null)
                return new ErrorResult();
            var data = await _discountRepository.GetAsync(x => x.Id == discount.Id);
            data = _mapper.Map(discount, data);
            _discountRepository.Update(data);
            await _discountRepository.SaveChangesAsync();
            return new SuccessResult();
        }
    }
}
