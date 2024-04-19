using System;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.CategoryTree
{
    public class HierarchyViewModel
    {
        public Guid Id { get; set; }
        public string text { get; set; }
        public Guid? perentId { get; set; }
        public virtual List<HierarchyViewModel> children { get; set; }
    }
}
