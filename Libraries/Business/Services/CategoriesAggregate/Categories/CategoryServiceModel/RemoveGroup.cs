using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class RemoveGroup
    {
        public int Id { get; set; }

        public RemoveGroup(int ıd)
        {
            Id = ıd;
        }

        public RemoveGroup()
        {
        }
    }
}
