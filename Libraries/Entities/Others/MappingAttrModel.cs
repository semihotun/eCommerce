using System.Collections.Generic;
namespace Entities.Others
{
    public class MappingAttrModel
    {
        public string MappingName { get; set; }
        public string ValueName { get; set; }
        public int MappingId { get; set; }
        public int AttributeId { get; set; }
        public List<MappingAttrModel> MappingAttrXmlList { get; set; }
    }
}
