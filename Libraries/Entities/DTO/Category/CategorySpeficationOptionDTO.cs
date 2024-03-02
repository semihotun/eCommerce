using Entities.Concrete.SpeficationAggregate;
using System.Collections.Generic;
namespace Entities.DTO.Category
{
    public class CategorySpeficationOptionDTO
    {
        public IEnumerable<SpecificationAttribute> CategorySpeficationList { get; set; }
        public class SpecificationAttribute
        {
            public string Name { get; set; }
            public int DisplayOrder { get; set; }
            public IEnumerable<SpecificationAttributeOption> SpecificationAttributeOptionList { get; set; }
        }
    }
}
