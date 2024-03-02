using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands.BrandDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.BrandAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands
{
    public interface IBrandDAL : IEntityRepository<Brand>
    {
        public Task<IDataResult<IPagedList<Brand>>> GetBrandDataTable(GetBrandDataTable request);
    }
}
