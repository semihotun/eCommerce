using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Dtos.ProductAttributeMappingDALModels
{
    public class ProductDetailMappingDTO
    {
        public Guid Id { get; set; }
        public string TextPrompt { get; set; }
        public IEnumerable<ProductAttributeValue> ProductAttributeValueList { get; set; }
    }
}
