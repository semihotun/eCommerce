namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels
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
