using System.Collections.Generic;
namespace Entities.Dtos.CategoryDALModels
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<CategoryDTO> SubCategory { get; set; }
    }
}
