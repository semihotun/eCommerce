using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.ViewModels.Admin
{
    public class HierarchyViewModel
    {
        public int Id { get; set; }
        public string text { get; set; }
        public int? perentId { get; set; }
        public virtual List<HierarchyViewModel> children { get; set; }
    }
}