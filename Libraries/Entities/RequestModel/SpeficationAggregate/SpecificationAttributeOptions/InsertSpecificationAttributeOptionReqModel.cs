using Entities.Concrete;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class InsertSpecificationAttributeOptionReqModel
    {
        public int SpecificationAttributeId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public InsertSpecificationAttributeOptionReqModel(int specificationAttributeId, string name, int displayOrder)
        {
            SpecificationAttributeId = specificationAttributeId;
            Name = name;
            DisplayOrder = displayOrder;
        }
        public InsertSpecificationAttributeOptionReqModel()
        {
            
        }
    }
}
