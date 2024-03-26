using Entities.Concrete.SpeficationAggregate;
using System.Collections.Generic;
using CategoryModel = Entities.Concrete.CategoriesAggregate.Category;
namespace Entities.DTO.Category
{
    public class CategorySpeficationDTO
    {
        public CategoryModel Category { get; set; }
        public IEnumerable<SpecificationAttribute> CategorySpeficationList { get; set; }
    }
}
