using Core.SeedWork;
using System;
namespace Entities.Concrete
{
    public class PredefinedProductAttributeValue : BaseEntity, IEntity
    {
        public Guid ProductAttributeId { get; set; }
        public string Name { get; set; }
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public decimal Cost { get; set; }
        public int DisplayOrder { get; set; }
    }
}
