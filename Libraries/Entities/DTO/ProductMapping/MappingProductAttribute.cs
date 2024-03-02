using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using Entities.Concrete.ProductAggregate;
namespace Entities.DTO.ProductMapping
{
    public class MappingProductAttribute
    {
        public int Id { get; set; }
        public string TextPrompt { get; set; }
        public IEnumerable<ProductAttributeValue> ProductAttributeList { get; set; }
    }
}
