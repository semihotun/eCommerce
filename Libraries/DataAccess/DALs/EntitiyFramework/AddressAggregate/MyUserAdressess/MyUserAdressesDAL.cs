using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.AdressAggregate;
namespace DataAccess.DALs.EntitiyFramework.AddressAggregate.MyUserAdressess
{
    public class MyUserAdressesDAL : EfEntityRepositoryBase<MyUserAdresses, eCommerceContext>, IMyUserAdressesDAL
    {
        public MyUserAdressesDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
