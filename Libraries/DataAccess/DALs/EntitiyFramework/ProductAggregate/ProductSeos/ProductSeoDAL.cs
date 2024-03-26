using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSeos
{
    public class ProductSeoDAL : EfEntityRepositoryBase<ProductSeo, ECommerceContext>, IProductSeoDAL
    {
        public ProductSeoDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
