namespace Entities.Concrete.AdressAggregate
{
    public class MyUserAdresses : BaseEntity
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
    }
}
