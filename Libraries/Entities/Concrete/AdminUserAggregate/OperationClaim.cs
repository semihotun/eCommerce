using eCommerce.Core.Entities;
namespace Entities.Concrete.AdminUserAggregate
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
