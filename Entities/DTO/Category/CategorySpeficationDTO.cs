using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Category
{
    public class CategorySpeficationDTO
    {
        public Entities.Concrete.Category Category { get; set; }

        public IList<SpecificationAttribute> CategorySpeficationList { get; set; }
    }
}
