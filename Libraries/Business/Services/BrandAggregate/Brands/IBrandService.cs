using Business.Services.BrandAggregate.Brands.BrandServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.BrandAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.BrandAggregate.Brands
{
    public interface IBrandService
    {
        Task<Result<IPagedList<Brand>>> GetBrandList(GetBrandList request);
        Task<Result> AddBrand(Brand model);
        Task<Result<Brand>> GetBrand(GetBrand request);
        Task<Result> DeleteBrand(Brand brand);
        Task<Result> UpdateBrand(Brand brand);
        Task<Result<IEnumerable<SelectListItem>>> GetBrandDropdown(GetBrandDropdown request);
    }
}
