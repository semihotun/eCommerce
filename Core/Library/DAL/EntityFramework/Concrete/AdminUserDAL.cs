using Core.Library.DAL.EntityFramework.Abstract;
using Core.Library.Entities.Concrete;
using eCommerce.Core.DataAccess.EntitiyFramework;

namespace Core.Library.DAL.EntityFramework.Concrete
{
    public class AdminUserDAL : EfEntityRepositoryBase<AdminUser, CoreContext>, IAdminUserDAL
    {
        public AdminUserDAL(CoreContext context) : base(context)
        {
        }

    }
}
