using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Context;
using Entities.Concrete.SpeficationAggregate;
namespace DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions
{
    public class SpecificationAttributeOptionDAL : EfEntityRepositoryBase<SpecificationAttributeOption, eCommerceContext>, ISpecificationAttributeOptionDAL
    {
        public SpecificationAttributeOptionDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
