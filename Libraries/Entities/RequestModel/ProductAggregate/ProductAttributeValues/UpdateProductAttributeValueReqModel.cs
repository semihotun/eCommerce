using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class UpdateProductAttributeValueReqModel
    {
        public Guid Id { get; set; }
        public Guid ProductAttributeMappingId { get; set; }
        public string? Name { get; set; }
        public int DisplayOrder { get; set; }
        public UpdateProductAttributeValueReqModel()
        {

        }
        public UpdateProductAttributeValueReqModel(Guid id, Guid productAttributeMappingId, string name, int displayOrder)
        {
            Id = id;
            ProductAttributeMappingId = productAttributeMappingId;
            Name = name;
            DisplayOrder = displayOrder;
        }
    }
}
