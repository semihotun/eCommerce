using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.BrandAggregate;

namespace DataAccess.DALs.EntitiyFramework.BrandAggregate.CatalogBrands
{

    public class CatalogBrandDAL : EfEntityRepositoryBase<CatalogBrand, eCommerceContext>, ICatalogBrandDAL
    {
        public CatalogBrandDAL(eCommerceContext context) : base(context)
        {
        }

    }
}
