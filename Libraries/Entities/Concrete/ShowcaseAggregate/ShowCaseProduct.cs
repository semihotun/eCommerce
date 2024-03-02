namespace Entities.Concrete.ShowcaseAggregate
{
    public class ShowCaseProduct : BaseEntity
    {
        public int ShowCaseId { get; set; }
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
    }
}
