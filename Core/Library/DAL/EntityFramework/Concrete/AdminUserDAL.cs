using Core.Library.DAL.EntityFramework.Abstract;
using Core.Library.Entities.Concrete;
using eCommerce.Core.DataAccess.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Library.DAL.EntityFramework.Concrete
{
    public class AdminUserDAL : EfEntityRepositoryBase<AdminUser, CoreContext>, IAdminUserDAL
    {
        public AdminUserDAL(CoreContext context) : base(context)
        {
        }

    }
}
