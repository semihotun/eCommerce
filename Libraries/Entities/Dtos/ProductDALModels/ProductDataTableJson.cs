using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace Entities.Dtos.ProductDALModels
{
    public class ProductDataTableJson
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoryId { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public ProductAttributeCombination ProductAttributeCombination { get; set; }
        public IEnumerable<ProductStock> ProductStockList { get; set; }
    }
}
