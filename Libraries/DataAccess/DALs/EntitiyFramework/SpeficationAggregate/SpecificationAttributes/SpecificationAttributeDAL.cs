using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.SpeficationAggregate;
namespace DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributes
{
    public class SpecificationAttributeDAL : EfEntityRepositoryBase<SpecificationAttribute, ECommerceContext>, ISpecificationAttributeDAL
    {
        public SpecificationAttributeDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
