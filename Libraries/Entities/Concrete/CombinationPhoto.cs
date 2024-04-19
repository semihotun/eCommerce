using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class CombinationPhoto : BaseEntity, IEntity
    {
        public Guid CombinationId { get; set; }
        public Guid PhotoId { get; set; }
    }
}
