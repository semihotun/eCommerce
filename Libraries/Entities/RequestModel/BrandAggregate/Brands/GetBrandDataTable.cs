using Core.Utilities.DataTable;
using Core.Utilities.Infrastructure.Filter;
using System;
namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class GetBrandDataTable : DTParameters, IFilterable
    {
        [Filter(FilterOperators.Equals)]
        public Guid Id { get; set; }
        [Filter(FilterOperators.Equals)]
        public string BrandName { get; set; }
    }
}
