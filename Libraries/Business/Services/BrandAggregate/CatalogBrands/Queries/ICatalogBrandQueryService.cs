using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.BrandAggregate.CatalogBrands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.BrandAggregate.CatalogBrands.Queries
{
    public interface ICatalogBrandQueryService
    {
        Task<Result<List<CatalogBrand>>> GetCatalogBrand(GetCatalogBrandReqModel request);
    }
}
