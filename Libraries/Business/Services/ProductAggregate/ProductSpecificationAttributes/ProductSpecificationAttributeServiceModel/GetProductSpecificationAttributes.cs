using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel
{
    public class GetProductSpecificationAttributes
    {
        public int ProductId { get; set; }
        public string SpecificationAttributeName { get; set; }
        public int SpecificationAttributeOptionId { get; set; }
        public bool? AllowFiltering { get; set; }
        public bool? ShowOnProductPage { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetProductSpecificationAttributes(int productId = 0,
            string specificationAttributeName = null,
            int specificationAttributeOptionId = 0,
            bool? allowFiltering = null,
            bool? showOnProductPage = null,
            int pageIndex = 1,
            int pageSize = int.MaxValue)
        {
            ProductId = productId;
            SpecificationAttributeName = specificationAttributeName;
            SpecificationAttributeOptionId = specificationAttributeOptionId;
            AllowFiltering = allowFiltering;
            ShowOnProductPage = showOnProductPage;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public GetProductSpecificationAttributes()
        {
        }
    }
}
