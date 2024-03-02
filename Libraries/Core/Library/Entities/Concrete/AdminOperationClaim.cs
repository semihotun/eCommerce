using eCommerce.Core.Entities;
namespace Core.Library.Entities.Concrete
{
    public class AdminOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
