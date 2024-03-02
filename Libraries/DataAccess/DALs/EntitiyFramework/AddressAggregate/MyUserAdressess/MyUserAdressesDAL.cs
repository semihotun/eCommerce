using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.AdressAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.AddressAggregate.MyUserAdressess
{
    public class MyUserAdressesDAL : EfEntityRepositoryBase<MyUserAdresses, eCommerceContext>, IMyUserAdressesDAL
    {
        public MyUserAdressesDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
