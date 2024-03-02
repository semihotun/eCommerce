using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.SpeficationAggregate;
namespace DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributes
{
    public class SpecificationAttributeDAL : EfEntityRepositoryBase<SpecificationAttribute, eCommerceContext>, ISpecificationAttributeDAL
    {
        public SpecificationAttributeDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
