using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.AdminUserAggregate;

namespace DataAccess.DALs.EntitiyFramework.AdminAggregate.AdminAuths
{
    public class AdminUserDAL : EfEntityRepositoryBase<AdminUser, CoreContext>, IAdminUserDAL
    {
        public AdminUserDAL(CoreContext context) : base(context)
        {
        }
    }
}
