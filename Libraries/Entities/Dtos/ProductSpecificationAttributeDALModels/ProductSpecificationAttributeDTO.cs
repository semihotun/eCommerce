using Core.SeedWork;
using System;

namespace Entities.Dtos.ProductSpecificationAttributeDALModels
{
    public class ProductSpecificationAttributeDTO : BaseEntity
    {
        public bool ShowOnProductPage { get; set; }
        public bool AllowFiltering { get; set; }
        public string CustomValue { get; set; }
        public Guid SpecificationAttributeOptionId { get; set; }
        public string SpecificationAttributeOptionName { get; set; }
        public int DisplayOrder { get; set; }
        public string SpeficationAtributeTypeName { get; set; }
    }
}
