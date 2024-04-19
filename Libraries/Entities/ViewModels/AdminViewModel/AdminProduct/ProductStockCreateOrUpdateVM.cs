using Core.SeedWork;
using System;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class ProductStockCreateOrUpdateVM : BaseEntity
    {
        public double? ProductPrice { get; set; }
        public double? ProductDiscount { get; set; }
        public int? ProductStockPiece { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
        public string ProductName { get; set; }
    }
}
