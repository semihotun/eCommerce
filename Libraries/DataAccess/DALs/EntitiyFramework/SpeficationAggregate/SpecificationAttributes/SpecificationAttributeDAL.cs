using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Context;
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
