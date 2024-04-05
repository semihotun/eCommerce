using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.SpeficationAggregate;
namespace DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions
{
    public class SpecificationAttributeOptionDAL : EfEntityRepositoryBase<SpecificationAttributeOption, ECommerceContext>, ISpecificationAttributeOptionDAL
    {
        public SpecificationAttributeOptionDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
