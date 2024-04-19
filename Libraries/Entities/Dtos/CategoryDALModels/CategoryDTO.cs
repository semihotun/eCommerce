using System;
using System.Collections.Generic;
namespace Entities.Dtos.CategoryDALModels
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public List<CategoryDTO> SubCategory { get; set; }
    }
}
