using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class GetSpecificationAttributeByIdReqModel
    {
        public GetSpecificationAttributeByIdReqModel(Guid specificationAttributeId)
        {
            SpecificationAttributeId = specificationAttributeId;
        }
        public Guid SpecificationAttributeId { get; set; }
        public GetSpecificationAttributeByIdReqModel()
        {

        }
    }
}
