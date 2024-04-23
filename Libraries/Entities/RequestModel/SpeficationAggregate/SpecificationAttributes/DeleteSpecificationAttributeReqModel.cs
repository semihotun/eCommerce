using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class DeleteSpecificationAttributeReqModel
    {
        public Guid Id { get; set; }
        public DeleteSpecificationAttributeReqModel(Guid id)
        {
            Id = id;
        }
        public DeleteSpecificationAttributeReqModel()
        {

        }
    }
}
