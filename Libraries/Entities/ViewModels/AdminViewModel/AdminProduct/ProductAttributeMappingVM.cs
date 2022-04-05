using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public partial class ProductAttributeMappingVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public int AttributeControlTypeId { get; set; }
        public int? DisplayOrder { get; set; }
        public string DefaultValue { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
        public IList<ProductAttributeValue> ProductAttributeValue { get; set; }
        public IList<ProductAttributeMapping> ProductAttributeMappingList { get; set; }
    }
}
