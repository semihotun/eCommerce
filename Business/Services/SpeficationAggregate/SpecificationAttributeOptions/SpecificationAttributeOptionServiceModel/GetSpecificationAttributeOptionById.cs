using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel
{
    public class GetSpecificationAttributeOptionById
    {
        public GetSpecificationAttributeOptionById(int? specificationAttributeOptionId)
        {
            SpecificationAttributeOptionId = specificationAttributeOptionId;
        }

        public int? SpecificationAttributeOptionId { get; set; }
    }
}
