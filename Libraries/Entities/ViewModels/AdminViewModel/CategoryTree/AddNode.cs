using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Entities.ViewModels.AdminViewModel.CategoryTree
{
    public class AddNode
    {
        [Required(ErrorMessage = "Node type is required.")]
        public string NodeTypeRbtn { get; set; }
        [Required(ErrorMessage = "Node Name is required.")]
        public string NodeName { get; set; }
        public int? ParentName { get; set; }
    }
}
