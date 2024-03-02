using eCommerce.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete.AdressAggregate;
namespace DataAccess.DALs.EntitiyFramework.AddressAggregate.Adress
{
    public interface IAddressDAL : IEntityRepository<Address>
    {
    }
}
