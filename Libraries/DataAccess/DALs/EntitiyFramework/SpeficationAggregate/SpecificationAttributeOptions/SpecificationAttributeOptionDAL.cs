using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
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
