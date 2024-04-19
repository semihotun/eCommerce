using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class GetNotExistingSpecificationAttributeOptionsReqModel
    {
        public GetNotExistingSpecificationAttributeOptionsReqModel(Guid[] attributeOptionIds)
        {
            AttributeOptionIds = attributeOptionIds;
        }
        public GetNotExistingSpecificationAttributeOptionsReqModel()
        {
            
        }
        public Guid[] AttributeOptionIds { get; set; }
    }
}
