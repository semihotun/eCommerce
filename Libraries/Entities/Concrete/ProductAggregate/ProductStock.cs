using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.Concrete.ProductAggregate
{
    public class ProductStock : BaseEntity
    {
        public double? ProductPrice { get; set; }
        public double? ProductDiscount { get; set; }
        public int? ProductStockPiece { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
    }
}
