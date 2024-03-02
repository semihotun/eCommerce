using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.AdressAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.AddressAggregate.Adress
{
    public class AddressDAL : EfEntityRepositoryBase<Address, eCommerceContext>, IAddressDAL
    {
        public AddressDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
