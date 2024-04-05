using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.AuthAggregate;

namespace DataAccess.DALs.EntitiyFramework.AdminAggregate.AdminAuths
{
    public class AdminUserDAL : EfEntityRepositoryBase<AdminUser, ECommerceContext>, IAdminUserDAL
    {
        public AdminUserDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
