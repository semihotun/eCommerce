using Core.Entities;

namespace Entities.Concrete.AuthAggregate
{
    public class AdminOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
