using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.Concrete.ProductAggregate
{
    public class ProductShipmentInfo : BaseEntity
    {
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public int ProductId { get; set; }
    }
}
