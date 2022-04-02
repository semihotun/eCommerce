using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete.ProductAggregate;

namespace Entities.DTO.ProductMapping
{
    public class ProductDetailMappingJson
    {
        public int Id { get; set; }
        public string TextPrompt { get; set; }
        public IEnumerable<ProductAttributeValue> ProductAttributeValueList { get; set; }
    }

}
