using Entities.Concrete;
using Entities.Concrete.SpeficationAggregate;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.SpeficationAttribute
{
    public class SpecificationAttributeVM : BaseEntity
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public virtual SpecificationAttributeOption SpecificationAttributeOptionModel { get; set; }
        public virtual ICollection<SpecificationAttributeOption> SpecificationAttributeOption { get; set; }
    }
}
