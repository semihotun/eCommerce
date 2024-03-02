using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
namespace Entities.DTO.ProductMapping
{
    public class MappingProductAttribute
    {
        public int Id { get; set; }
        public string TextPrompt { get; set; }
        public IEnumerable<ProductAttributeValue> ProductAttributeList { get; set; }
    }
}
