using Core.SeedWork;
namespace Entities.Concrete
{
    public class ProductAttribute : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
