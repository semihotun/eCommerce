
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Infrastructure.Filter;

namespace Entities.ViewModels.Admin.Products.ProductStock
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
