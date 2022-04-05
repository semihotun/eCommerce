using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Context;
using Entities.Concrete.ShowcaseAggregate;

namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowCaseProducts
{
    public class ShowCaseProductDAL : EfEntityRepositoryBase<ShowCaseProduct, eCommerceContext>, IShowCaseProductDAL
    {
        public ShowCaseProductDAL(eCommerceContext context) : base(context)
        {
        }

    }
}
