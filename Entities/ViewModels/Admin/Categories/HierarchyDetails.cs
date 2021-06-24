using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.ViewModels.Admin
{
    public partial class HierarchyDetails
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string HierarchyName { get; set; }

        public int? PerentId { get; set; }
    }
}