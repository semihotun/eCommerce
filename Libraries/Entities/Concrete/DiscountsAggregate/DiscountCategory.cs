namespace Entities.Concrete.DiscountsAggregate
{
    public class DiscountCategory : BaseEntity
    {
        public int DiscountId { get; set; }
        public int CategoryId { get; set; }
    }
}
