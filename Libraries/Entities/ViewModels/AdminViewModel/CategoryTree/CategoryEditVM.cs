using Entities.Concrete;
using Entities.Concrete.CategoriesAggregate;
using Entities.Dtos.CategoryDALModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.CategoryTree
{
    public class CategoryEditVM : BaseEntity
    {
        public virtual CategorySpeficationDTO CategorySpeficationDTO { get; set; }
        public virtual CategorySpefication CategorySpefication { get; set; }
        public IEnumerable<SelectListItem> SpeficationAttributeSelectList { get; set; }
    }
}
