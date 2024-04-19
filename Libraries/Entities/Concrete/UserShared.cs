using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class UserShared : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public Guid RoleId { get; set; }
    }
}
