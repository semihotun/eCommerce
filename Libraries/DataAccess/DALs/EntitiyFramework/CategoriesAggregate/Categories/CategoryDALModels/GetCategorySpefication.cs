using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels
{
    public class GetCategorySpefication
    {
        public GetCategorySpefication(int categoryId)
        {
            CategoryId = categoryId;
        }

        public GetCategorySpefication()
        {
        }

        public int CategoryId { get; set; }
    }
}
