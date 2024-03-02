using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ShowcaseAggregate;
namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseTypes
{
    public class ShowcaseTypeDAL : EfEntityRepositoryBase<ShowCaseType, eCommerceContext>, IShowcaseTypeDAL
    {
        public ShowcaseTypeDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
