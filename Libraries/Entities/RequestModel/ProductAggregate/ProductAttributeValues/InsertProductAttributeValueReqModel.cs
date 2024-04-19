using Entities.Concrete;
using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class InsertProductAttributeValueReqModel
    {
        public Guid ProductAttributeMappingId { get; set; }
        public string? Name { get; set; }
        public Guid DisplayOrder { get; set; }
        public InsertProductAttributeValueReqModel()
        {
            
        }
        public InsertProductAttributeValueReqModel(Guid productAttributeMappingId, string name, Guid displayOrder)
        {
            ProductAttributeMappingId = productAttributeMappingId;
            Name = name;
            DisplayOrder = displayOrder;
        }
    }
}
