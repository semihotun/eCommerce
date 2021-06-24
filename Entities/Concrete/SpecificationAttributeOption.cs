
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public partial class SpecificationAttributeOption : BaseEntity
    {

        public int SpecificationAttributeId { get; set; }
        public string Name { get; set; }

        public string ColorSquaresRgb { get; set; }

        public int DisplayOrder { get; set; }
    }
}
