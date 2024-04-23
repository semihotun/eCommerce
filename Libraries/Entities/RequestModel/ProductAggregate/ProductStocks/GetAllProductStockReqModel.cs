using Core.Utilities.DataTable;
using Core.Utilities.Infrastructure.Filter;
using System;
namespace Entities.RequestModel.ProductAggregate.ProductStocks
{
    public class GetAllProductStockReqModel : DTParameters, IFilterable
    {
        [Filter(FilterOperators.GreaterThan)]
        public double? ProductPrice { get; set; }
        [Filter(FilterOperators.GreaterThan)]
        public double? ProductDiscount { get; set; }
        [Filter(FilterOperators.GreaterThan)]
        public int? ProductStockPiece { get; set; }
        [Filter(FilterOperators.Equals)]
        public bool AllowOutOfStockOrders { get; set; }
        [Filter(FilterOperators.Equals)]
        public bool NotifyAdminForQuantityBelow { get; set; }
        public DateTime CreateTime { get; set; }
        [Filter(FilterOperators.Equals)]
        public Guid ProductId { get; set; }
        [Filter(FilterOperators.Equals)]
        public int CombinationId { get; set; }
    }
}
