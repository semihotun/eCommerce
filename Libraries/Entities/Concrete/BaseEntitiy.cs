using eCommerce.Core.Entities;
namespace Entities.Concrete
{
    public class BaseEntity : IEntity
    {
        public int Id
        {
            get;
            set;
        }
    }
}
