using Entities.Concrete;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class DeleteSpecificationAttributeOptionReqModel
    {
        public int Id { get; set; }
        public DeleteSpecificationAttributeOptionReqModel()
        {
            
        }
        public DeleteSpecificationAttributeOptionReqModel(int id)
        {
            Id = id;
        }
    }
}
