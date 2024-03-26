using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues
{
    public class ProductAttributeValueDAL : EfEntityRepositoryBase<ProductAttributeValue, ECommerceContext>, IProductAttributeValueDAL
    {
        public ProductAttributeValueDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
