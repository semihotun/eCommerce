using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.BrandAggregate.Brands;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.BrandAggregate.Brands.Queries
{
    public interface IBrandQueryService
    {
        Task<Result<IPagedList<Brand>>> GetBrandList(GetBrandListReqModel request);
        Task<Result<Brand>> GetBrand(GetBrandReqModel request);
        Task<Result<IEnumerable<SelectListItem>>> GetBrandDropdown(GetBrandDropdownReqModel request);
    }
}
