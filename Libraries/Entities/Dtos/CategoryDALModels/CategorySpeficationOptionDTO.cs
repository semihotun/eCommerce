using Entities.Concrete;
using System.Collections.Generic;
namespace Entities.Dtos.CategoryDALModels
{
    public class CategorySpeficationOptionDTO
    {
        public List<SpecificationAttribute> CategorySpeficationList { get; set; }
        public class SpecificationAttribute
        {
            public string Name { get; set; }
            public int DisplayOrder { get; set; }
            public IEnumerable<SpecificationAttributeOption> SpecificationAttributeOptionList { get; set; }
        }
        public List<CatalogBrand> CatalogBrandList { get; set; }
    }
}
