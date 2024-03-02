using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.CategoriesAggregate.CategorySpefications.CategorySpeficationServiceModel
{
    public class GetAllCategorySpefication
    {
        public GetAllCategorySpefication(int categoryId)
        {
            CategoryId = categoryId;
        }
        public GetAllCategorySpefication()
        {
        }
        public int CategoryId { get; set; }
    }
}
