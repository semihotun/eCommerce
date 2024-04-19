using Core.SeedWork;
using Entities.Concrete;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.SpeficationAttributes
{
    public class SpecificationAttributeVM : BaseEntity
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public virtual SpecificationAttributeOption SpecificationAttributeOptionModel { get; set; }
        public virtual ICollection<SpecificationAttributeOption> SpecificationAttributeOption { get; set; }
    }
}
