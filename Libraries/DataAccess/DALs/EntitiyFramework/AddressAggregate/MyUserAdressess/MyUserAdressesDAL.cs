using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.AdressAggregate;
namespace DataAccess.DALs.EntitiyFramework.AddressAggregate.MyUserAdressess
{
    public class MyUserAdressesDAL : EfEntityRepositoryBase<MyUserAdresses, ECommerceContext>, IMyUserAdressesDAL
    {
        public MyUserAdressesDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
