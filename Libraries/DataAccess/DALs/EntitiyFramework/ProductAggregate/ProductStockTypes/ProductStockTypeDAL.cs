using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStockTypes
{
    public class ProductStockTypeDAL : EfEntityRepositoryBase<ProductStockType, eCommerceContext>, IProductStockTypeDAL
    {
        public ProductStockTypeDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
