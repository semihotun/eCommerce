using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
namespace Entities.Dtos.ProductAttributeMappingDALModels
{
    public class ProductDetailMappingPageJson
    {
        public int Id { get; set; }
        public string TextPrompt { get; set; }
        public IEnumerable<ProductAttributeValue> ProductAttributeValueList { get; set; }
    }
}
