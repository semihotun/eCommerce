using System;
using System.ComponentModel.DataAnnotations;
namespace Entities.ViewModels.AdminViewModel.CategoryTree
{
    public class AddNode
    {
        [Required(ErrorMessage = "Node type is required.")]
        public string NodeTypeRbtn { get; set; }
        [Required(ErrorMessage = "Node Name is required.")]
        public string NodeName { get; set; }
        public Guid? ParentId { get; set; }
    }
}
