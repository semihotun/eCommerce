using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.AdressAggregate;
namespace DataAccess.DALs.EntitiyFramework.AddressAggregate.Adress
{
    public class AddressDAL : EfEntityRepositoryBase<Address, ECommerceContext>, IAddressDAL
    {
        public AddressDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
