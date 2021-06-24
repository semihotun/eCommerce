using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class MyUserAdresses:BaseEntity
    {
        public int AddressId { get; set; }

        public int UserId{ get; set; }
    }
}
