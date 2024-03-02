using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSeos
{
    public class ProductSeoDAL : EfEntityRepositoryBase<ProductSeo, eCommerceContext>, IProductSeoDAL
    {
        public ProductSeoDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
