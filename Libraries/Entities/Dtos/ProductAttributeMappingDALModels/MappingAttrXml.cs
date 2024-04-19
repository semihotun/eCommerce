using System;
using System.Collections.Generic;
namespace Entities.Dtos.ProductAttributeMappingDALModels
{
    public class MappingAttrXml
    {
        public string MappingName { get; set; }
        public string ValueName { get; set; }
        public Guid MappingId { get; set; }
        public Guid AttributeId { get; set; }
        public List<MappingAttrXml> MappingAttrXmlList { get; set; }
    }
}