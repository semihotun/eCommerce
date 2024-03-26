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
    public class BrandDAL : EfEntityRepositoryBase<Brand, ECommerceContext>, IBrandDAL
    {
        public BrandDAL(ECommerceContext context) : base(context)
        {
        }
        [CacheAspect]
        public async Task<Result<IPagedList<Brand>>> GetBrandDataTable(GetBrandDataTable request)
        {
            return Result.SuccessDataResult(
                await (from b in Context.Brand.ApplyFilter(request.Brand)
                       select b)
                       .ApplyDataTableFilter(request.DataTableParam)
                       .OrderBy(request.DataTableParam.SortOrder)
                       .ToPagedListAsync(request.DataTableParam.PageIndex, request.DataTableParam.PageSize));
        }
    }
}
