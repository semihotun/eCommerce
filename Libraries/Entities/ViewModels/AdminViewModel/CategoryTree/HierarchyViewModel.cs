using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.ViewModels.AdminViewModel.CategoryTree
{
    public class HierarchyViewModel
    {
        public int Id { get; set; }
        public string text { get; set; }
        public int? perentId { get; set; }
        public virtual List<HierarchyViewModel> children { get; set; }
    }
}
