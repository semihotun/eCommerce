using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
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
