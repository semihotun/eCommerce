using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class GetMappingProductAttributeListReqModel
    {
        public Guid MappingId { get; set; }
        public GetMappingProductAttributeListReqModel(Guid mappingId)
        {
            MappingId = mappingId;
        }
        public GetMappingProductAttributeListReqModel()
        {
        }
    }
}
