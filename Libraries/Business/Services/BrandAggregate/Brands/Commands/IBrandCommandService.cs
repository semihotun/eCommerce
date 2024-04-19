using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.BrandAggregate.Brands;
using System.Threading.Tasks;

namespace Business.Services.BrandAggregate.Brands.Commands
{
    public interface IBrandCommandService
    {
        Task<Result<Brand>> AddBrand(AddBrandReqModel request);
        Task<Result> DeleteBrand(DeleteBrandReqModel request);
        Task<Result> UpdateBrand(UpdateBrandReqModel request);
    }
}
