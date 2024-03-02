using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.ProductAggregate.Products.ProductServiceModel
{
    public class GetProductsBySpecificationAttributeId
    {
        public GetProductsBySpecificationAttributeId(int specificationAttributeId, int pageIndex = 1, int pageSize = int.MaxValue)
        {
            SpecificationAttributeId = specificationAttributeId;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public GetProductsBySpecificationAttributeId()
        {
        }
        public int SpecificationAttributeId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
