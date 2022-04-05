using Core.Utilities.Infrastructure.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Brand
{
    public class BrandDataTableFilter:IFilterable
    {
        [Filter(FilterOperators.Equals)]
        public int Id { get; set; }

        [Filter(FilterOperators.Equals)]
        public string BrandName { get; set; }


    }
}
