using Entities.Concrete;

namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class InsertProductSpecificationAttributeReqModel
    {
        public int ProductId { get; set; }
        public int AttributeTypeId { get; set; }
        public int SpecificationAttributeOptionId { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public int DisplayOrder { get; set; }
        public InsertProductSpecificationAttributeReqModel()
        {
            
        }
        public InsertProductSpecificationAttributeReqModel(int productId, int attributeTypeId, int specificationAttributeOptionId,
            bool allowFiltering, bool showOnProductPage, int displayOrder)
        {
            ProductId = productId;
            AttributeTypeId = attributeTypeId;
            SpecificationAttributeOptionId = specificationAttributeOptionId;
            AllowFiltering = allowFiltering;
            ShowOnProductPage = showOnProductPage;
            DisplayOrder = displayOrder;
        }
    }
}
