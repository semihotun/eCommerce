using Core.Utilities.Infrastructure.Filter;
using System;
using System.Collections.Generic;
using System.Text;

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

        public Brand BrandModel { get; set; }
        public class Brand:IFilterable
        {
            [Filter(FilterOperators.Equals)]
            public int Id { get; set; }
   
        }

    }
}
