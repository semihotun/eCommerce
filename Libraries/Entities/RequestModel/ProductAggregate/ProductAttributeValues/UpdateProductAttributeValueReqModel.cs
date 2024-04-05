using Entities.Concrete;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class UpdateProductAttributeValueReqModel
    {
        public int Id { get; set; }
        public int ProductAttributeMappingId { get; set; }
        public string? Name { get; set; }
        public int DisplayOrder { get; set; }
        public UpdateProductAttributeValueReqModel()
        {
            
        }
        public UpdateProductAttributeValueReqModel(int id, int productAttributeMappingId, string name, int displayOrder)
        {
            Id = id;
            ProductAttributeMappingId = productAttributeMappingId;
            Name = name;
            DisplayOrder = displayOrder;
        }
    }
}
