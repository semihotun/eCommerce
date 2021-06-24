using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entities.Concrete
{
    public class MyUser : IdentityUser<int>
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(60)]
        public string Surname { get; set; }
        public string ActivationCode { get; set; }
        //public virtual ICollection<Comment> Comment { get; set; }
        //public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
        //public virtual ICollection<MyUserAdresses> MyUserAdresses { get; set; }
        //public virtual ICollection<Order> OrderList { get; set; }
    }
    public class MyUserRole : IdentityUserRole<int> { }
    public class MyRole : IdentityRole<int> { }
    public class MyClaim : IdentityUserClaim<int> { }
    public class MyLogin : IdentityUserLogin<int> { }

    public class MyRoleClaim : IdentityRoleClaim<int> { }
    public class MyUserToken : IdentityUserToken<int> { }
    //public class ApplicationDbContext : IdentityDbContext<MyUser, MyRole, int, MyClaim, MyUserRole, MyLogin, MyRoleClaim, MyUserToken>
    //{

    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    //          : base(options)
    //    {

    //    }
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        modelBuilder.Entity<MyUser>()
    //        .ToTable("Users");

    //        modelBuilder.Entity<MyRole>()
    //            .ToTable("Role");

    //        modelBuilder.Entity<MyUserRole>()
    //            .ToTable("UserRole");

    //        modelBuilder.Entity<MyClaim>()
    //            .ToTable("Claim");

    //        modelBuilder.Entity<MyLogin>()
    //            .ToTable("Login");

    //        modelBuilder.Entity<MyUser>().Property(r => r.Id).ValueGeneratedOnAdd();

    //        modelBuilder.Entity<MyRole>().Property(r => r.Id).ValueGeneratedOnAdd();

    //        modelBuilder.Entity<MyClaim>().Property(r => r.Id).ValueGeneratedOnAdd();


    //    }
    //}
}