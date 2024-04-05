using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.BrandAggregate;
namespace DataAccess.DALs.EntitiyFramework.BrandAggregate.CatalogBrands
{
    public class CatalogBrandDAL : EfEntityRepositoryBase<CatalogBrand, ECommerceContext>, ICatalogBrandDAL
    {
        public CatalogBrandDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
