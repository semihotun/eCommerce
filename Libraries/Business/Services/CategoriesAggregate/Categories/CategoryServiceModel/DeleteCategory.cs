using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class DeleteCategory
    {
        public int Id { get; set; }
        public DeleteCategory(int ıd)
        {
            Id = ıd;
        }
        public DeleteCategory()
        {
        }
    }
}
