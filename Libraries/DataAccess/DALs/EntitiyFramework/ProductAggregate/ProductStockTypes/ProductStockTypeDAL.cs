using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStockTypes
{
    public class ProductStockTypeDAL : EfEntityRepositoryBase<ProductStockType, ECommerceContext>, IProductStockTypeDAL
    {
        public ProductStockTypeDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
