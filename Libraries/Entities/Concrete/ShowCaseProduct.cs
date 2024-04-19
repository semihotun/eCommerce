using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class ShowCaseProduct : BaseEntity, IEntity
    {
        public Guid ShowCaseId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
    }
}
