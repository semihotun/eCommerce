using Entities.Concrete;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class UpdateSpecificationAttributeOptionReqModel
    {
        public int Id { get; set; }
        public int SpecificationAttributeId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public UpdateSpecificationAttributeOptionReqModel(int id, int specificationAttributeId, string name, int displayOrder)
        {
            Id = id;
            SpecificationAttributeId = specificationAttributeId;
            Name = name;
            DisplayOrder = displayOrder;
        }
        public UpdateSpecificationAttributeOptionReqModel()
        {
            
        }
    }
}
