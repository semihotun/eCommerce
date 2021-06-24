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
    public class SpecificationAttributeOptionDAL : EfEntityRepositoryBase<SpecificationAttributeOption, eCommerceContext>, ISpecificationAttributeOptionDAL
    {
        public SpecificationAttributeOptionDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
