using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
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
