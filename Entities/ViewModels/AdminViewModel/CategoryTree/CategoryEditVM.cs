using Entities.Concrete;
using Entities.Concrete.CategoriesAggregate;
using Entities.DTO.Category;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.AdminViewModel.CategoryTree
{
    public class CategoryEditVM : BaseEntity
    {
        public virtual CategorySpeficationDTO CategorySpeficationDTO { get; set; }
        public virtual CategorySpefication CategorySpefication { get; set; }

        public IEnumerable<SelectListItem> SpeficationAttributeSelectList { get; set; }
    }
}
