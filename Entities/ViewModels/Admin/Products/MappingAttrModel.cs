using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.ViewModels.Admin
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