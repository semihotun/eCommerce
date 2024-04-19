using Core.SeedWork;
using System;
namespace Entities.Concrete
{
    public class ProductShipmentInfo : BaseEntity, IEntity
    {
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public Guid ProductId { get; set; }
    }
}
