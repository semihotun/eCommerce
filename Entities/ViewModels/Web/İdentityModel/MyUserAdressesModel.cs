
using Entities.ViewModels.Web;
using EEntities.ViewModels.Web;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Web
{
    public class MyUserAdressesModel:BaseEntity
    {

        public int AddressId { get; set; }

        public int UserId{ get; set; }

        public virtual AddressModel Address { get; set; }

        public virtual MyUser MyUser { get; set; }
    }
}
