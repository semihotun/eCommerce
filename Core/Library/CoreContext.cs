using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core.Library.Entities.Concrete;

namespace Core.Library
{

    public class CoreContext : IdentityDbContext<MyUser, MyRole, int, MyClaim, MyUserRole, MyLogin, MyRoleClaim, MyUserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-OB76QRL\\SQLEXPRESS;initial catalog=eCommerce;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {

        }

        public virtual DbSet<AdminUser> AdminUser { get; set; }
    }
}
