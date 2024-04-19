using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class ProductAttributeMappingVM
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public Guid AttributeControlTypeId { get; set; }
        public Guid? DisplayOrder { get; set; }
        public string DefaultValue { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
        public IList<ProductAttributeValue> ProductAttributeValue { get; set; }
        public IList<ProductAttributeMapping> ProductAttributeMappingList { get; set; }
    }
}
