using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
namespace Entities.DTO.ProductMapping
{
    public class ProductDetailMappingJson
    {
        public int Id { get; set; }
        public string TextPrompt { get; set; }
        public IEnumerable<ProductAttributeValue> ProductAttributeValueList { get; set; }
    }
}
