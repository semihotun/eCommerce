using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.BrandAggregate;
using Entities.RequestModel.BrandAggregate.Brands;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.BrandAggregate.Brands
{
    public interface IBrandService
    {
        Task<Result<IPagedList<Brand>>> GetBrandList(GetBrandListReqModel request);
        Task<Result<Brand>> AddBrand(AddBrandReqModel model);
        Task<Result<Brand>> GetBrand(GetBrandReqModel request);
        Task<Result> DeleteBrand(DeleteBrandReqModel brand);
        Task<Result> UpdateBrand(UpdateBrandReqModel brand);
        Task<Result<IEnumerable<SelectListItem>>> GetBrandDropdown(GetBrandDropdownReqModel request);
    }
}
