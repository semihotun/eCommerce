using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
namespace Entities.Dtos.ProductDALModels
{
    public class ProductDataTableJson
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public ProductAttributeCombination ProductAttributeCombination { get; set; }
        public IEnumerable<ProductStock> ProductStockList { get; set; }
    }
}
