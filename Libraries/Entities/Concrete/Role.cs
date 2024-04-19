using Core.SeedWork;

namespace Entities.Concrete
{
    public class Role : BaseEntity, IEntity
    {
        public string RoleName { get; set; }
    }
}
