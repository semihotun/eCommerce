using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class GetSpecificationAttributeByIdsReqModel
    {
        public GetSpecificationAttributeByIdsReqModel(Guid[] specificationAttributeIds)
        {
            SpecificationAttributeIds = specificationAttributeIds;
        }
        public Guid[] SpecificationAttributeIds { get; set; }
        public GetSpecificationAttributeByIdsReqModel()
        {

        }
    }
}
