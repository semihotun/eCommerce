using Entities.Concrete;
using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class DeleteSpecificationAttributeOptionReqModel
    {
        public Guid Id { get; set; }
        public DeleteSpecificationAttributeOptionReqModel()
        {
            
        }
        public DeleteSpecificationAttributeOptionReqModel(Guid id)
        {
            Id = id;
        }
    }
}
