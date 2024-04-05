using Core.Utilities.Results;
using Entities.Concrete.BrandAggregate;
using Entities.RequestModel.BrandAggregate.CatalogBrands;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.BrandAggregate.CatalogBrands
{
    public interface ICatalogBrandService
    {
        Task<Result<IEnumerable<CatalogBrand>>> GetCatalogBrand(GetCatalogBrandReqModel request);
    }
}
