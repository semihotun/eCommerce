using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Entities.DTO
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