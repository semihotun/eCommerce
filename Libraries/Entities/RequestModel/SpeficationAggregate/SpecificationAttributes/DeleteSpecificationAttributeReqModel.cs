using Entities.Concrete;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class DeleteSpecificationAttributeReqModel
    {
        public int Id { get; set; }
        public DeleteSpecificationAttributeReqModel(int id)
        {
            Id = id;
        }
        public DeleteSpecificationAttributeReqModel()
        {
            
        }
    }
}
