using Core.Utilities.Infrastructure.Filter;
using System;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class ProductStockFilter : IFilterable
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
        public int ProductId { get; set; }
        [Filter(FilterOperators.Equals)]
        public int CombinationId { get; set; }
    }
}
