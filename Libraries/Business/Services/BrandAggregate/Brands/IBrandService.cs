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
        Task<IDataResult<IPagedList<Brand>>> GetBrandList(GetBrandList request);
        Task<IResult> AddBrand(Brand model);
        Task<IDataResult<Brand>> GetBrand(GetBrand request);
        Task<IResult> DeleteBrand(Brand brand);
        Task<IResult> UpdateBrand(Brand brand);
        Task<IDataResult<IEnumerable<SelectListItem>>> GetBrandDropdown(GetBrandDropdown request);
    }
}
