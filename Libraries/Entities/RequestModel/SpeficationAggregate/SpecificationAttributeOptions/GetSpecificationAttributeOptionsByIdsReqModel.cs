using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class GetSpecificationAttributeOptionsByIdsReqModel
    {
        public GetSpecificationAttributeOptionsByIdsReqModel(Guid[] specificationAttributeOptionIds)
        {
            SpecificationAttributeOptionIds = specificationAttributeOptionIds;
        }
        public GetSpecificationAttributeOptionsByIdsReqModel()
        {

        }
        public Guid[] SpecificationAttributeOptionIds { get; set; }
    }
}
