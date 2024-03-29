﻿using Core.Utilities.Infrastructure.Filter;
namespace Entities.DTO.Product
{
    public class ProductDataTableFilter : IFilterable
    {
        [Filter(FilterOperators.Equals)]
        public int Id { get; set; }
        [Filter(FilterOperators.Equals)]
        public string ProductName { get; set; }
        [Filter(FilterOperators.GreaterThan)]
        public int ProductPrice { get; set; }
        [Filter(FilterOperators.GreaterThan)]
        public int ProductStock { get; set; }
        [Filter(FilterOperators.Equals)]
        public int CategoryId { get; set; }
        [Filter(FilterOperators.Equals)]
        public bool ProductShow { get; set; }
        public BrandDataTableFilter BrandModel { get; set; }
    }
    public class BrandDataTableFilter : IFilterable
    {
        [Filter(FilterOperators.Equals)]
        public int Id { get; set; }
    }
}
