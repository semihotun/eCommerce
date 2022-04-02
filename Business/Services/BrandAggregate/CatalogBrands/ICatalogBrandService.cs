using Business.Services.BrandAggregate.CatalogBrands.CatalogBrandModels;
using Core.Utilities.Results;
using Entities.Concrete.BrandAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.BrandAggregate.CatalogBrands
{
    public interface ICatalogBrandService
    {
        Task<IDataResult<IEnumerable<CatalogBrand>>> GetCatalogBrand(GetCatalogBrand request);
    }
}
