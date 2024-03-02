using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.PhotoAggregate;
namespace DataAccess.DALs.EntitiyFramework.PhotoAggregate.ProductPhotos
{
    public class ProductPhotoDAL : EfEntityRepositoryBase<ProductPhoto, eCommerceContext>, IProductPhotoDAL
    {
        public ProductPhotoDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
