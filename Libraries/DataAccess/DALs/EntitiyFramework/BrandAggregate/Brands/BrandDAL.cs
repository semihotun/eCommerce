using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands.BrandDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.BrandAggregate;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands
{
    public class BrandDAL : EfEntityRepositoryBase<Brand, eCommerceContext>, IBrandDAL
    {
        public BrandDAL(eCommerceContext context) : base(context)
        {
        }
        public async Task<IDataResult<IPagedList<Brand>>> GetBrandDataTable(GetBrandDataTable request)
        {
            var query = from b in Context.Brand.ApplyDataTableFilter(request.DataTableParam).ApplyFilter(request.Brand)
                        select b;

            var data = await query.OrderBy(request.DataTableParam.SortOrder)
                .ToPagedListAsync(request.DataTableParam.PageIndex, request.DataTableParam.PageSize);

            return new SuccessDataResult<IPagedList<Brand>>(data);
        }
    }
}
