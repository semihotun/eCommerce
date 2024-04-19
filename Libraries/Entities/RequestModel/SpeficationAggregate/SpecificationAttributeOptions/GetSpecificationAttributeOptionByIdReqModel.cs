using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class GetSpecificationAttributeOptionByIdReqModel
    {
        public GetSpecificationAttributeOptionByIdReqModel(Guid? specificationAttributeOptionId)
        {
            SpecificationAttributeOptionId = specificationAttributeOptionId;
        }
        public GetSpecificationAttributeOptionByIdReqModel()
        {
            
        }
        public Guid? SpecificationAttributeOptionId { get; set; }
    }
}
