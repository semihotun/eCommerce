using Entities.ViewModels.Web.SpecifationAttr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.ViewModels.Web
{
    public class CategorySpeficationModel : BaseEntity
    {
        public int? CategoryId { get; set; }

        public int? SpeficationAttributeId { get; set; }
        public string SpeficationAttributeName { get; set; }

        public virtual CategoryModel Category { get; set; }

        public virtual SpecificationAttributeModel SpecificationAttribute { get; set; }
    }
}
