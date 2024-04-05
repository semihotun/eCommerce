using Entities.Concrete;
using System;

namespace Entities.RequestModel.ProductAggregate.ProductStocks
{
    public class AddProductStockReqModel
    {
        public double? ProductPrice { get; set; }
        public double? ProductDiscount { get; set; }
        public int? ProductStockPiece { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public DateTime CreateTime { get; set; }
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public AddProductStockReqModel()
        {
            
        }
        public AddProductStockReqModel(double? productPrice, double? productDiscount, int? productStockPiece, bool allowOutOfStockOrders,
            int notifyAdminForQuantityBelow, DateTime createTime, int productId, int combinationId)
        {
            ProductPrice = productPrice;
            ProductDiscount = productDiscount;
            ProductStockPiece = productStockPiece;
            AllowOutOfStockOrders = allowOutOfStockOrders;
            NotifyAdminForQuantityBelow = notifyAdminForQuantityBelow;
            CreateTime = createTime;
            ProductId = productId;
            CombinationId = combinationId;
        }
    }
}
