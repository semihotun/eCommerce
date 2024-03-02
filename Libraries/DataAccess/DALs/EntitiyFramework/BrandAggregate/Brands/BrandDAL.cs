using Core.Aspects.Autofac.Caching;
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
        [CacheAspect]
        public async Task<IDataResult<IPagedList<Brand>>> GetBrandDataTable(GetBrandDataTable request)
        {
            var query = from b in Context.Brand.ApplyFilter(request.Brand)
                        select b;
            query=query.ApplyDataTableFilter(request.DataTableParam);
            var data = await query.OrderBy(request.DataTableParam.SortOrder)
                .ToPagedListAsync(request.DataTableParam.PageIndex, request.DataTableParam.PageSize);
            return new SuccessDataResult<IPagedList<Brand>>(data);
        }
    }
}
