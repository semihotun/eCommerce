using Entities.ViewModels.Web.SpecifationAttr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.ViewModels.Web
{
    public class CatalogFilterModel
    {
        public int? CategoryId { get; set; }
        public int? SpeficationAttributeId { get; set; }
        public string SpeficationAttributeName { get; set; }
        public string CategoryName { get; set; }
        public CatalogSpecificationAttributeModel SpecificationAttribute{ get; set; }

    }
    public class CatalogSpecificationAttributeModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public List<CatalogSpecificationAttributeOptionModel> SpecificationAttributeOption { get; set; }
    }
    public class CatalogSpecificationAttributeOptionModel
    {
        public int Id { get; set; }
        public int SpecificationAttributeId { get; set; }
        public string Name { get; set; }
        public string ColorSquaresRgb { get; set; }
        public int DisplayOrder { get; set; }
    }

}
