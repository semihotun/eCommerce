using Core.SeedWork;
using System;
namespace Entities.Concrete
{
    public class ProductAttributeCombination : BaseEntity, IEntity
    {
        public Guid ProductId { get; set; }
        public string AttributesXml { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public string ManufacturerPartNumber { get; set; }
    }
}
