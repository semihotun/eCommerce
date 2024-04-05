using Entities.Concrete;
using System;

namespace Entities.RequestModel.ProductAggregate.Products
{
    public class CreateOrUpdateProductReqModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string ProductContent { get; set; }
        public bool? ProductShow { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int ProductStockTypeId { get; set; }
        public string ProductNameUpper { get; set; }
        public CreateOrUpdateProductReqModel()
        {
            
        }
        public CreateOrUpdateProductReqModel(int id, string productName, int? brandId, int? categoryId, string productContent, bool? productShow, string gtin, string sku, DateTime createdOnUtc, int productStockTypeId, string productNameUpper)
        {
            Id = id;
            ProductName = productName;
            BrandId = brandId;
            CategoryId = categoryId;
            ProductContent = productContent;
            ProductShow = productShow;
            Gtin = gtin;
            Sku = sku;
            CreatedOnUtc = createdOnUtc;
            ProductStockTypeId = productStockTypeId;
            ProductNameUpper = productNameUpper;
        }
    }
}
