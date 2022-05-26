using Core.Library.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace Core.Library
{
    public class CoreContext : IdentityDbContext<MyUser, MyRole, int, MyClaim, MyUserRole, MyLogin, MyRoleClaim, MyUserToken>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlServerOptionsExtension = optionsBuilder.Options.
                  FindExtension<SqlServerOptionsExtension>();

            var connectionString = sqlServerOptionsExtension.ConnectionString;

            optionsBuilder.UseSqlServer(connectionString);
        }

        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {

        }

        public virtual DbSet<AdminUser> AdminUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyUser>().ToTable("IdentityUsers");
            modelBuilder.Entity<MyRole>().ToTable("IdentityRole");
            modelBuilder.Entity<MyClaim>().ToTable("IdentityClaim");
            modelBuilder.Entity<MyUserRole>().ToTable("IdentityUserRole");
            modelBuilder.Entity<MyLogin>().ToTable("IdentityLogin");
            modelBuilder.Entity<MyRoleClaim>().ToTable("IdentityRoleClaim");
            modelBuilder.Entity<MyUserToken>().ToTable("IdentityUserToken");


            modelBuilder.Entity<MyUser>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MyRole>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MyClaim>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MyUserRole>().HasNoKey();
            modelBuilder.Entity<MyLogin>().HasNoKey();
            modelBuilder.Entity<MyRoleClaim>().HasNoKey();
            modelBuilder.Entity<MyUserToken>().HasNoKey();

           
        }
    }
}
