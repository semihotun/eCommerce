using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
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
