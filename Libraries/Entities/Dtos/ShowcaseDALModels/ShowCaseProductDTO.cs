using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace Entities.Dtos.ShowcaseDALModels
{
    public class ShowCaseProductDTO
    {
        public Guid Id { get; set; }
        public Guid ShowCaseId { get; set; }
        public Guid ProductId { get; set; }
        public string ShowCaseText { get; set; }
        public Product ProductModel { get; set; }
        public class Product
        {
            public Guid Id { get; set; }
            public string ProductName { get; set; }
            public DateTime CreatedOnUtc { get; set; }
            public IEnumerable<ProductPhoto> ProductPhotoList { get; set; }
            public ProductStock ProductStock { get; set; }
            public ProductAttributeCombination ProductAttributeCombination { get; set; }
        }
    }
}
