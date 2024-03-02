using Business.Services.DiscountsAggregate.DiscountBrands.DiscountBrandServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.DiscountsAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.DiscountsAggregate.DiscountBrands
{
    public interface IDiscountBrandService
    {
        Task<IDataResult<IPagedList<DiscountBrand>>> GetAllDiscountBrand(GetAllDiscountBrand request);
        Task<IResult> AddDiscountBrand(DiscountBrand discountBrand);
        Task<IResult> DeleteDiscountBrand(DiscountBrand discountBrand);
    }
}
