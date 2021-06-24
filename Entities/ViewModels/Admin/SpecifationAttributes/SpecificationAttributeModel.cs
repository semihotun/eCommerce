
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Admin
{
    public partial class SpecificationAttributeModel : BaseEntity
    {

        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public virtual SpecificationAttributeOptionModel SpecificationAttributeOptionModel { get; set; }
        public virtual ICollection<SpecificationAttributeOptionModel> SpecificationAttributeOption { get; set; }
    }
}
