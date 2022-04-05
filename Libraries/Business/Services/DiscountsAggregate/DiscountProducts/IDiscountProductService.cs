using Business.Services.DiscountsAggregate.DiscountProducts.DiscountProductServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.DiscountsAggregate;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Services.DiscountsAggregate.DiscountProducts
{
    public interface IDiscountProductService
    {
        Task<IDataResult<IPagedList<DiscountProduct>>> GetAllDiscountProduct(GetAllDiscountProduct request);
        Task<IResult> AddDiscountProduct(DiscountProduct discountProduct);
        Task<IResult> DeleteDiscountProduct(DiscountProduct discountProduct);
    }
}
