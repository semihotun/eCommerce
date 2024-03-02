using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Core.Library
{
    public class MyUser : IdentityUser<int>
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(60)]
        public string Surname { get; set; }
        public string ActivationCode { get; set; }
    }
    public class MyUserRole : IdentityUserRole<int> { }
    public class MyRole : IdentityRole<int> { }
    public class MyClaim : IdentityUserClaim<int> { }
    public class MyLogin : IdentityUserLogin<int> { }
    public class MyRoleClaim : IdentityRoleClaim<int> { }
    public class MyUserToken : IdentityUserToken<int> { }
}