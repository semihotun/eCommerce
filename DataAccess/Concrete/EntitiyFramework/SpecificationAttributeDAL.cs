using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class SpecificationAttributeDAL : EfEntityRepositoryBase<SpecificationAttribute, eCommerceContext>, ISpecificationAttributeDAL
    {

        public SpecificationAttributeDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
