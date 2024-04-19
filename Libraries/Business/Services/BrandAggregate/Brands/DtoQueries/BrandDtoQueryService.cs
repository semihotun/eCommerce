using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.BrandAggregate.Brands;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Business.Services.BrandAggregate.Brands.DtoQueries
{
    public class BrandDtoQueryService : IBrandDtoQueryService
    {
        private readonly IReadDbRepository<Brand> _readContext;
        public BrandDtoQueryService(IReadDbRepository<Brand> readContext)
        {
            _readContext = readContext;
        }
        /// <summary>
        /// Get Brand DataTable
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<Brand>>> GetBrandDataTable(GetBrandDataTable request)
        {
            var data = await _readContext.Query().ApplyFilter(request)
                                        .ApplyDataTableFilter(request)
                                        .OrderBy(request.SortOrder)
                                        .ToPagedListAsync(request.PageIndex, request.PageSize);

            return Result.SuccessDataResult(data);
        }
    }
}
