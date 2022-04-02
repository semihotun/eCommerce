using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands.BrandDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.BrandAggregate;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccess.DALs.EntitiyFramework.BrandAggregate.CatalogBrands
{
    public interface ICatalogBrandDAL : IEntityRepository<CatalogBrand>
    {
    }
}
