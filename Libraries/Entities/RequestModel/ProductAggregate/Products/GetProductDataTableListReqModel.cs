using Core.Utilities.DataTable;
using Core.Utilities.Infrastructure.Filter;
using System;

namespace Entities.RequestModel.ProductAggregate.Products
{
    public class GetProductDataTableListReqModel : DTParameters , IFilterable
    {
        [Filter(FilterOperators.Equals)]
        public Guid Id { get; set; }
        [Filter(FilterOperators.Equals)]
        public string ProductName { get; set; }
        [Filter(FilterOperators.GreaterThan)]
        public int ProductPrice { get; set; }
        [Filter(FilterOperators.GreaterThan)]
        public int ProductStock { get; set; }
        [Filter(FilterOperators.Equals)]
        public Guid CategoryId { get; set; }
        [Filter(FilterOperators.Equals)]
        public bool ProductShow { get; set; }
        [Filter(FilterOperators.Equals)]
        public Guid BrandId { get; set; }
    }
}
