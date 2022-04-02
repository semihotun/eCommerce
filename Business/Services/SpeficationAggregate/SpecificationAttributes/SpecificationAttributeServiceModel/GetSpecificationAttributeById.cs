using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel
{
    public class GetSpecificationAttributeById
    {
        public GetSpecificationAttributeById(int specificationAttributeId)
        {
            SpecificationAttributeId = specificationAttributeId;
        }

        public int SpecificationAttributeId { get; set; }
    }
}
