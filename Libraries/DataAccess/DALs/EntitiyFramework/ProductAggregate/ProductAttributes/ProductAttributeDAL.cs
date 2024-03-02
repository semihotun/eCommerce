using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributes
{
    public partial class ProductAttributeDAL : EfEntityRepositoryBase<ProductAttribute, eCommerceContext>, IProductAttributeDAL
    {
        public ProductAttributeDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
