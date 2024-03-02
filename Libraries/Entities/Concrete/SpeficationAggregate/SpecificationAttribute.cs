using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.Concrete.SpeficationAggregate
{
    public partial class SpecificationAttribute : BaseEntity
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
