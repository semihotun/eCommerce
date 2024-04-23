using System;

namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class GetProductSpecificationAttributesReqModel
    {
        public Guid ProductId { get; set; }
        public string SpecificationAttributeName { get; set; }
        public Guid SpecificationAttributeOptionId { get; set; }
        public bool? AllowFiltering { get; set; }
        public bool? ShowOnProductPage { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetProductSpecificationAttributesReqModel()
        {

        }
        public GetProductSpecificationAttributesReqModel(Guid productId,
            string? specificationAttributeName,
            Guid specificationAttributeOptionId,
            bool? allowFiltering,
            bool? showOnProductPage,
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
    }
}
