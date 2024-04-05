using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.ProductAggregate;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributes
{
    public class ProductAttributeDAL : EfEntityRepositoryBase<ProductAttribute, ECommerceContext>, IProductAttributeDAL
    {
        public ProductAttributeDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
