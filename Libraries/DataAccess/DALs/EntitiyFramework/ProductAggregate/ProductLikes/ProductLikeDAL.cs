using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductLikes
{
    public class ProductLikeDAL : EfEntityRepositoryBase<ProductLike, eCommerceContext>, IProductLikeDAL
    {
        public ProductLikeDAL(eCommerceContext context) : base(context)
        {
          
        }
    }
}
