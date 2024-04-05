using Entities.Concrete;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class InsertProductAttributeValueReqModel
    {
        public int ProductAttributeMappingId { get; set; }
        public string? Name { get; set; }
        public int DisplayOrder { get; set; }
        public InsertProductAttributeValueReqModel()
        {
            
        }
        public InsertProductAttributeValueReqModel(int productAttributeMappingId, string name, int displayOrder)
        {
            ProductAttributeMappingId = productAttributeMappingId;
            Name = name;
            DisplayOrder = displayOrder;
        }
    }
}
