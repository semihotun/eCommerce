using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel
{
    public class GetSpecificationAttributeByIds
    {
        public GetSpecificationAttributeByIds(int[] specificationAttributeIds)
        {
            SpecificationAttributeIds = specificationAttributeIds;
        }
        public GetSpecificationAttributeByIds()
        {
        }
        public int[] SpecificationAttributeIds { get; set; }
    }
}
