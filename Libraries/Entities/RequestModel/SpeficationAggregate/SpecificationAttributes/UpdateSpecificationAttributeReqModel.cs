using Entities.Concrete;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class UpdateSpecificationAttributeReqModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public UpdateSpecificationAttributeReqModel(string name, int displayOrder)
        {
            Name = name;
            DisplayOrder = displayOrder;
        }
        public UpdateSpecificationAttributeReqModel()
        {
            
        }
    }
}
