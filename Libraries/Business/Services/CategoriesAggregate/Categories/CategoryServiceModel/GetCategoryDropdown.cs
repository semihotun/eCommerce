using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class GetCategoryDropdown
    {
        public GetCategoryDropdown(int? selectedId)
        {
            SelectedId = selectedId;
        }
        public GetCategoryDropdown()
        {

        }

        public int? SelectedId { get; set; }
    }
}
