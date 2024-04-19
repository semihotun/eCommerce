using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class InsertProductAttributeMappingReqModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public Guid AttributeControlTypeId { get; set; }
        public int DisplayOrder { get; set; }
        public string DefaultValue { get; set; }
        public InsertProductAttributeMappingReqModel()
        {
            
        }
        public InsertProductAttributeMappingReqModel(Guid productId,
            Guid productAttributeId,
            string textPrompt,
            bool ısRequired,
            Guid attributeControlTypeId,
            int displayOrder,
            string defaultValue)
        {
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
