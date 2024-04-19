using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class MyUserAdresses : BaseEntity, IEntity
    {
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
    }
}
