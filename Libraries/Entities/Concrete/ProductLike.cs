using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class ProductLike : BaseEntity, IEntity
    {
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
        public Guid UserId { get; set; }
    }
}
