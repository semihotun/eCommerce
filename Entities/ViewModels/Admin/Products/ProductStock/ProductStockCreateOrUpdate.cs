using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Admin.Products.ProductStock
{
    public class ProductStockCreateOrUpdate : BaseEntity
    {
        public double? ProductPrice { get; set; }
        public double? ProductDiscount { get; set; }
        public int? ProductStockPiece { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public string ProductName { get; set; }
    }
}
