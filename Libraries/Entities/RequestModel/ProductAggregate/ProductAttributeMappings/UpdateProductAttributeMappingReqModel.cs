namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class UpdateProductAttributeMappingReqModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public int AttributeControlTypeId { get; set; }
        public int DisplayOrder { get; set; }
        public string DefaultValue { get; set; }
        public UpdateProductAttributeMappingReqModel()
        {
            
        }
        public UpdateProductAttributeMappingReqModel(int id, int productId,
            int productAttributeId,
            string textPrompt, bool ısRequired, int attributeControlTypeId, int displayOrder, string defaultValue)
        {
            Id = id;
            ProductId = productId;
            ProductAttributeId = productAttributeId;
            TextPrompt = textPrompt;
            IsRequired = ısRequired;
            AttributeControlTypeId = attributeControlTypeId;
            DisplayOrder = displayOrder;
            DefaultValue = defaultValue;
        }
    }
}
