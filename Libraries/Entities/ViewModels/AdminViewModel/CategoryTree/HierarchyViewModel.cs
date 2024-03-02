using System.Collections.Generic;
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
