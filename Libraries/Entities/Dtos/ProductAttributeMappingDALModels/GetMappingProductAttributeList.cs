namespace Entities.Dtos.ProductAttributeMappingDALModels
{
    public class GetMappingProductAttributeList
    {
        public int MappingId { get; set; }
        public GetMappingProductAttributeList(int mappingId)
        {
            MappingId = mappingId;
        }
        public GetMappingProductAttributeList()
        {
        }
    }
}
