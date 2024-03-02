using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.DTO
{
    public class ProductSpecificationAttributeDTO : BaseEntity
    {
        public bool ShowOnProductPage { get; set; }
        public bool AllowFiltering { get; set; }
        public string CustomValue { get; set; }
        public int SpecificationAttributeOptionId { get; set; }
        public string SpecificationAttributeOptionName { get; set; }
        public int DisplayOrder { get; set; }
        public string SpeficationAtributeTypeName { get; set; }
    }
}
