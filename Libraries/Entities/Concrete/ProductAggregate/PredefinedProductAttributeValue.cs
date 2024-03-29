namespace Entities.Concrete.ProductAggregate
{
    public class PredefinedProductAttributeValue : BaseEntity
    {
        public int ProductAttributeId { get; set; }
        public string Name { get; set; }
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public decimal Cost { get; set; }
        public int DisplayOrder { get; set; }
    }
}
