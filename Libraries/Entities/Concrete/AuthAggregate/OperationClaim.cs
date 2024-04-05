using Core.Entities;

namespace Entities.Concrete.AuthAggregate
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
