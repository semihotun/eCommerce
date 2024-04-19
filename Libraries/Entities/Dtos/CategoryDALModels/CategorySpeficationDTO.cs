using Entities.Concrete;
using System.Collections.Generic;
using CategoryModel = Entities.Concrete.Category;
namespace Entities.Dtos.CategoryDALModels
{
    public class CategorySpeficationDTO
    {
        public CategoryModel Category { get; set; }
        public IEnumerable<SpecificationAttribute> CategorySpeficationList { get; set; }
    }
}
