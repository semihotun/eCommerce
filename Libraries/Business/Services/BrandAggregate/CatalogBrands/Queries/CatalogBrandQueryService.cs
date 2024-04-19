using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.BrandAggregate.CatalogBrands;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.BrandAggregate.CatalogBrands.Queries
{
    public class CatalogBrandQueryService : ICatalogBrandQueryService
    {
        private readonly IReadDbRepository<CatalogBrand> _catalogBrandRepository;
        public CatalogBrandQueryService(IReadDbRepository<CatalogBrand> catalogBrandRepository)
        {
            _catalogBrandRepository = catalogBrandRepository;
        }

        public async Task<Result<List<CatalogBrand>>> GetCatalogBrand(GetCatalogBrandReqModel request)
        {
            var data = await _catalogBrandRepository.ToListAsync(x => x.CategoryId == request.CategoryId);
            return Result.SuccessDataResult(data);
        }
    }
}
