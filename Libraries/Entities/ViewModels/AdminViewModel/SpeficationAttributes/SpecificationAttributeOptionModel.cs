using Core.SeedWork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.SpeficationAttributes
{
    public partial class SpecificationAttributeOptionVM : BaseEntity
    {
        public Guid SpecificationAttributeId { get; set; }
        public virtual SpecificationAttribute SpecificationAttribute { get; set; }
        public virtual List<ProductSpecificationAttribute> ProductSpecificationAttribute { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
