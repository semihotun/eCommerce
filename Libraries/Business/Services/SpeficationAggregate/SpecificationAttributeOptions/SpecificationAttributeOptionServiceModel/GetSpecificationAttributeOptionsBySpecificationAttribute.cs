using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel
{
    public class GetSpecificationAttributeOptionsBySpecificationAttribute
    {
        public GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeId, int pageIndex, int pageSize)
        {
            SpecificationAttributeId = specificationAttributeId;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeId)
        {
            SpecificationAttributeId = specificationAttributeId;
            PageIndex = 1;
            PageSize = 10;
        }
        public GetSpecificationAttributeOptionsBySpecificationAttribute()
        {
        }
        public int SpecificationAttributeId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
