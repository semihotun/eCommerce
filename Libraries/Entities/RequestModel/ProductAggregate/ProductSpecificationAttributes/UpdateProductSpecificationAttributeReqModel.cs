namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class UpdateProductSpecificationAttributeReqModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AttributeTypeId { get; set; }
        public int SpecificationAttributeOptionId { get; set; }
        public bool AllowFiltering { get; set; }
        public bool ShowOnProductPage { get; set; }
        public int DisplayOrder { get; set; }
        public UpdateProductSpecificationAttributeReqModel()
        {
            
        }

        public UpdateProductSpecificationAttributeReqModel(int id, int productId, int attributeTypeId, int specificationAttributeOptionId, bool allowFiltering,
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
