using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels
{
    public class GetCategorySpeficationOptionDTO
    {
        public GetCategorySpeficationOptionDTO(int categoryId)
        {
            CategoryId = categoryId;
        }

        public GetCategorySpeficationOptionDTO()
        {
        }

        public int CategoryId { get; set; }
    }
}
