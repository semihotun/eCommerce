using Core.SeedWork;

namespace Entities.Concrete
{
    public class SpecificationAttribute : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
