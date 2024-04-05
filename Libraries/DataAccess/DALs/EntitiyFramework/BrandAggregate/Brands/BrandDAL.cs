using Core.Aspects.Autofac.Caching;
using Core.DataAccess.EntitiyFramework;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete.BrandAggregate;
using Entities.Dtos.BrandDALModels;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
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
                await (from b in Context.Brand.ApplyFilter(request)
                       select b)
                       .ApplyDataTableFilter(request)
                       .OrderBy(request.SortOrder)
                       .ToPagedListAsync(request.PageIndex, request.PageSize));
        }
    }
}
