using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class UpdateProductAttributeMappingReqModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public Guid AttributeControlTypeId { get; set; }
        public int DisplayOrder { get; set; }
        public string DefaultValue { get; set; }
        public UpdateProductAttributeMappingReqModel()
        {
            
        }
        public UpdateProductAttributeMappingReqModel(Guid id, Guid productId,
            Guid productAttributeId,
            string textPrompt, bool ısRequired, Guid attributeControlTypeId, int displayOrder, string defaultValue)
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
