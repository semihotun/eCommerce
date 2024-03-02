using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues
{
    public class ProductAttributeValueDAL : EfEntityRepositoryBase<ProductAttributeValue, eCommerceContext>, IProductAttributeValueDAL
    {
        public ProductAttributeValueDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
