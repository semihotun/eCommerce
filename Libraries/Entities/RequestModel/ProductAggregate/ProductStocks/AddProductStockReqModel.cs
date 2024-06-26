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
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
        public AddProductStockReqModel()
        {

        }
        public AddProductStockReqModel(double? productPrice, double? productDiscount, int? productStockPiece, bool allowOutOfStockOrders,
            int notifyAdminForQuantityBelow, Guid productId, Guid combinationId)
        {
            ProductPrice = productPrice;
            ProductDiscount = productDiscount;
            ProductStockPiece = productStockPiece;
            AllowOutOfStockOrders = allowOutOfStockOrders;
            NotifyAdminForQuantityBelow = notifyAdminForQuantityBelow;
            ProductId = productId;
            CombinationId = combinationId;
        }
    }
}
