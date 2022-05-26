using Entities.Concrete.PhotoAggregate;
using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Product
{
    public class CatalogProduct
    {
        public string CreatedOnUtc { get; set; }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public ProductAttributeCombination ProductAttributeCombination { get; set; }
        public ProductStock ProductStockModel { get; set; }
        public ProductPhoto ProductPhotoModel { get; set; }
        
        public bool SpeficationIn { get; set; }
    }
}



