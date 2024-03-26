using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.PredefinedProductAttributeValues
{
    public class PredefinedProductAttributeValueDAL : EfEntityRepositoryBase<PredefinedProductAttributeValue, ECommerceContext>, IPredefinedProductAttributeValueDAL
    {
        public PredefinedProductAttributeValueDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
