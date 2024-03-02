using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.PhotoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.PhotoAggregate.ProductPhotos
{
    public class ProductPhotoDAL : EfEntityRepositoryBase<ProductPhoto, eCommerceContext>, IProductPhotoDAL
    {
        public ProductPhotoDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
