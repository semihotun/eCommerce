using System.Collections.Generic;
namespace Entities.Dtos.ProductAttributeMappingDALModels
{
    public class MappingAttrXml
    {
        public string MappingName { get; set; }
        public string ValueName { get; set; }
        public int MappingId { get; set; }
        public int AttributeId { get; set; }
        public List<MappingAttrXml> MappingAttrXmlList { get; set; }
    }
}