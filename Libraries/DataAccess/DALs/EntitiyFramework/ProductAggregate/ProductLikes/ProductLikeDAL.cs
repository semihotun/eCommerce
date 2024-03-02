using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductLikes
{
    public class ProductLikeDAL : EfEntityRepositoryBase<ProductLike, eCommerceContext>, IProductLikeDAL
    {
        public ProductLikeDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
