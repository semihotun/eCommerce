using Entities.Concrete;
using System;
namespace Entities.Dtos.ProductDALModels
{
    public class CatalogProduct
    {
        public string CreatedOnUtc { get; set; }
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? CategoryId { get; set; }
        public ProductAttributeCombination ProductAttributeCombination { get; set; }
        public ProductPhoto ProductPhotoModel { get; set; }
        public bool SpeficationIn { get; set; }
    }
}
