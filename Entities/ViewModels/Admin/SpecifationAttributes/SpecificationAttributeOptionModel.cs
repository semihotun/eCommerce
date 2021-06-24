
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Admin
{
    public partial class SpecificationAttributeOptionModel : BaseEntity
    {

        public int SpecificationAttributeId { get; set; }
        public virtual SpecificationAttributeModel SpecificationAttribute { get; set; }

        public virtual List<ProductSpecificationAttributeModel> ProductSpecificationAttribute { get; set; }

        public string Name { get; set; }

        public string ColorSquaresRgb { get; set; }

        public int DisplayOrder { get; set; }
    }
}
