using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.PhotoAggregate;
namespace DataAccess.DALs.EntitiyFramework.PhotoAggregate.ProductPhotos
{
    public class ProductPhotoDAL : EfEntityRepositoryBase<ProductPhoto, ECommerceContext>, IProductPhotoDAL
    {
        public ProductPhotoDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
