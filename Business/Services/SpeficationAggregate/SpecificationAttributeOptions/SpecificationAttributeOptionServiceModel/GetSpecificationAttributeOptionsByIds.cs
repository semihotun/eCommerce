using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel
{
    public class GetSpecificationAttributeOptionsByIds
    {
        public GetSpecificationAttributeOptionsByIds(int[] specificationAttributeOptionIds)
        {
            SpecificationAttributeOptionIds = specificationAttributeOptionIds;
        }

        public int[] SpecificationAttributeOptionIds { get; set; }
    }
}
