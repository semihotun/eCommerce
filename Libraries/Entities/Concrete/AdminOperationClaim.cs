using Core.SeedWork;
using System;

namespace Entities.Concrete
{
    public class AdminOperationClaim : BaseEntity, IEntity
    {
        public Guid UserId { get; set; }
        public Guid OperationClaimId { get; set; }
    }
}
