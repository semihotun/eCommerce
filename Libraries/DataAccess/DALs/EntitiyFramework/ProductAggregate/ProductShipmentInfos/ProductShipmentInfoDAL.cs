using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductShipmentInfos
{
    public class ProductShipmentInfoDAL : EfEntityRepositoryBase<ProductShipmentInfo, ECommerceContext>, IProductShipmentInfoDAL
    {
        public ProductShipmentInfoDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
