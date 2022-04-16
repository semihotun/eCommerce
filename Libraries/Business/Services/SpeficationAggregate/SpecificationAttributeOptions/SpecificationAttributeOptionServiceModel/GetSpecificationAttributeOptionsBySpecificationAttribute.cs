using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel
{
    public class GetSpecificationAttributeOptionsBySpecificationAttribute
    {
        public GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeId, int pageIndex, int pageSize)
        {
            SpecificationAttributeId = 0;
            PageIndex = 1;
            PageSize = int.MaxValue;
        }
        public GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeId)
        {
            SpecificationAttributeId = 0;
        }

        public GetSpecificationAttributeOptionsBySpecificationAttribute()
        {
        }

        public int SpecificationAttributeId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }
}
