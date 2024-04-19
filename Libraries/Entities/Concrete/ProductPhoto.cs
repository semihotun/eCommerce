using Core.SeedWork;
using System;
namespace Entities.Concrete
{
    public class ProductPhoto : BaseEntity, IEntity
    {
        public string ProductPhotoName { get; set; }
        public Guid? ProductId { get; set; }
    }
}
