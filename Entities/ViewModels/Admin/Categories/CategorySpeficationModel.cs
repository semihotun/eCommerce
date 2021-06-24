
using Entities.Concrete;
using Entities.DTO.Category;
using Entities.ViewModels.Web.SpecifationAttr;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.ViewModels.Admin
{
    public class CategorySpeficationModel : BaseEntity
    {
        public virtual CategorySpeficationDTO CategorySpeficationDTO { get; set; }
        public virtual CategorySpefication CategorySpefication { get; set; }

        public IEnumerable<SelectListItem> SpeficationAttributeSelectList { get; set; }
    }
}
