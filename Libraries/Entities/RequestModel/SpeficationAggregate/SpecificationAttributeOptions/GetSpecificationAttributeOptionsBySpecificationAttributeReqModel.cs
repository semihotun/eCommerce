using Core.Utilities.DataTable;
using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class GetSpecificationAttributeOptionsBySpecificationAttributeReqModel : DTParameters
    {
        public Guid SpecificationAttributeId { get; set; }
    }
}
