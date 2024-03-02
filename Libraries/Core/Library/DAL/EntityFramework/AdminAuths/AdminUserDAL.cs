using Core.Library.Entities.Concrete;
using eCommerce.Core.DataAccess.EntitiyFramework;
namespace Core.Library.DAL.EntityFramework.AdminAuths
{
    public class AdminUserDAL : EfEntityRepositoryBase<AdminUser, CoreContext>, IAdminUserDAL
    {
        public AdminUserDAL(CoreContext context) : base(context)
        {
        }
    }
}
