using Entities.Concrete;
using System;
namespace Entities.Dtos.ProductStockDALModels
{
    public class ProductStockDto
    {
        public Guid Id { get; set; }
        public double? ProductPrice { get; set; }
        public double? ProductDiscount { get; set; }
        public int? ProductStockPiece { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
        public string ProductName { get; set; }
        public Product Product { get; set; }
        public ProductAttributeCombination ProductAttributeCombination { get; set; }
    }
}
