using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Business.Abstract.Brands
{
    public  interface  IBrandService
    {
        Task<IDataResult<IPagedList<Brand>>> GetBrandList(string brandName = null,
             int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null);

        Task<IResult> BrandAdd(Brand model);
        Task<IDataResult<Brand>>GetBrand(int brandId = 0);
        Task<IResult> DeleteBrand(Brand brand);
        Task<IResult> UpdateBrand(Brand brand);
        Task<IDataResult<IEnumerable<SelectListItem>>> GetBrandDropdown(int? selectedId = 0);
    }
}
