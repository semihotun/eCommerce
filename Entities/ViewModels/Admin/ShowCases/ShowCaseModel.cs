
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.DTO.ShowCase;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Entities.ViewModels.Admin
{


    public class ShowCaseModel
    {
        public int Id { get; set; }
        public int ShowCaseOrder { get; set; }
        public string ShowCaseTitle { get; set; }
        public int SearchProductId { get; set; }
        public string SearchProductName { get; set; }
        public int ShowCaseType { get; set; }
        [UIHint("tinymce_full")]
        public string ShowCaseText { get; set; }
        public string Tap { get; set; }
        public ShowCaseDTO ShowCaseDto { get; set; }
        public ProductModel ProductModel { get; set; }
        public IEnumerable<SelectListItem> ShowCaseTypeList { get; set; }
        public IEnumerable<SelectListItem> BrandSelectListItems { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }

    }
}
