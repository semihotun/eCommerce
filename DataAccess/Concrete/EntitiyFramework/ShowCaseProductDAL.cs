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
    public  class ShowCaseProductDAL : EfEntityRepositoryBase<ShowCaseProduct, eCommerceContext>, IShowCaseProductDAL
    {
        public ShowCaseProductDAL(eCommerceContext context) : base(context)
        {
        }

    }
}
