using System;

namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class UpdateProductSpecificationAttributeReqModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid AttributeTypeId { get; set; }
        public Guid SpecificationAttributeOptionId { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public int DisplayOrder { get; set; }
        public UpdateProductSpecificationAttributeReqModel()
        {

        }

        public UpdateProductSpecificationAttributeReqModel(Guid id, Guid productId, Guid attributeTypeId, Guid specificationAttributeOptionId, bool allowFiltering,
            bool showOnProductPage, int displayOrder)
        {
            Id = id;
            ProductId = productId;
            AttributeTypeId = attributeTypeId;
            SpecificationAttributeOptionId = specificationAttributeOptionId;
            AllowFiltering = allowFiltering;
            ShowOnProductPage = showOnProductPage;
            DisplayOrder = displayOrder;
        }
    }
}
