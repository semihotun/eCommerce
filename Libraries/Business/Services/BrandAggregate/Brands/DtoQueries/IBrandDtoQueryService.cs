using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.BrandAggregate.Brands;
using System.Threading.Tasks;

namespace Business.Services.BrandAggregate.Brands.DtoQueries
{
    public interface IBrandDtoQueryService
    {
        public Task<Result<IPagedList<Brand>>> GetBrandDataTable(GetBrandDataTable request);
    }
}
