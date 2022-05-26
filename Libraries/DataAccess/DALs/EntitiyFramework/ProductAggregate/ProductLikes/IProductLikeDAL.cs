using eCommerce.Core.DataAccess;
using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductLikes
{
    public interface IProductLikeDAL : IEntityRepository<ProductLike>
    {
    }
}
