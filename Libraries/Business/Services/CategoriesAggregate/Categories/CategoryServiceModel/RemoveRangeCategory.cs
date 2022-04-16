using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class RemoveRangeCategory
    {
        public RemoveRangeCategory(int ıd)
        {
            Id = ıd;
        }

        public RemoveRangeCategory()
        {
        }

        public int Id { get; set; }
    }
}
