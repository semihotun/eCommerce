using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class ShowcaseTypeDAL : EfEntityRepositoryBase<ShowCaseType, eCommerceContext>, IShowcaseTypeDAL
    {
        public ShowcaseTypeDAL(eCommerceContext context) : base(context)
        {
        }

    }
}

