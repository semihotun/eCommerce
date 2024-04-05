using Core.DataAccess;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.BrandAggregate;
using Entities.Dtos.BrandDALModels;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.BrandAggregate.Brands
{
    public interface IBrandDAL : IEntityRepository<Brand>
    {
        public Task<Result<IPagedList<Brand>>> GetBrandDataTable(GetBrandDataTable request);
    }
}
